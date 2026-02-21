using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using resturant.Domain.DTOs;
using resturant.Domain.Entities;
using resturant.Domain.Interfaces;

namespace resturant.Application.Services;

public interface IUserService
{
    Task<AuthResponseDto> LoginAsync(LoginDto dto);
    Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
    Task<UserDto?> GetByIdAsync(long id);
    Task<UserDto> UpdateProfileAsync(long id, UserDto dto);
    Task AddLoyaltyPointsAsync(long userId, int points);

    // Management Methods
    Task<List<UserManagementDto>> GetAllUsersAsync();
    Task<UserDetailDto?> GetUserDetailAsync(long id);
    Task<UserDetailDto> CreateUserAsync(UserDetailDto dto);
    Task UpdateUserAsync(long id, UserDetailDto dto);
    Task DeleteUserAsync(long id);
    Task<bool> DeactivateUserAsync(long id);
    Task<bool> ActivateUserAsync(long id);
    Task AssignRolesToUserAsync(long userId, List<long> roleIds);
    Task<List<RoleDto>> GetAllRolesAsync();
    Task<RoleDto?> GetRoleByIdAsync(long id);
    Task<RoleDto> CreateRoleAsync(RoleDto dto);
    Task UpdateRoleAsync(long id, RoleDto dto);
    Task DeleteRoleAsync(long id);
    Task AssignPermissionsToRoleAsync(long roleId, List<long> permissionIds);
    Task<List<PermissionDto>> GetAllPermissionsAsync();
    Task<ManagementSummaryDto> GetManagementSummaryAsync();
}

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        var user = (await _unitOfWork.AppUsers.FindAsync(u => u.Email == dto.Email)).FirstOrDefault();
        
        if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = "Invalid email or password"
            };
        }

        if (!user.IsActive)
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = "Account is deactivated"
            };
        }

        var token = GenerateJwtToken(user);
        var refreshToken = GenerateRefreshToken();

        return new AuthResponseDto
        {
            Success = true,
            Token = token,
            RefreshToken = refreshToken,
            User = MapToDto(user)
        };
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
    {
        var existingUser = (await _unitOfWork.AppUsers.FindAsync(u => u.Email == dto.Email)).FirstOrDefault();
        if (existingUser != null)
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = "Email already registered"
            };
        }

        var user = new AppUser
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Phone = dto.Phone ?? "",
            Email = dto.Email,
            PasswordHash = HashPassword(dto.Password),
            RegistrationDate = DateTime.UtcNow,
            CustomerType = "Regular",
            LoyaltyPoints = 0,
            TotalSpent = 0,
            VisitCount = 0,
            IsActive = true
        };

        await _unitOfWork.AppUsers.AddAsync(user);

        var token = GenerateJwtToken(user);
        var refreshToken = GenerateRefreshToken();

        return new AuthResponseDto
        {
            Success = true,
            Token = token,
            RefreshToken = refreshToken,
            User = MapToDto(user)
        };
    }

    public async Task<UserDto?> GetByIdAsync(long id)
    {
        var user = await _unitOfWork.AppUsers.GetByIdAsync(id);
        return user != null ? MapToDto(user) : null;
    }

    public async Task<UserDto> UpdateProfileAsync(long id, UserDto dto)
    {
        var user = await _unitOfWork.AppUsers.GetByIdAsync(id);
        if (user == null) throw new InvalidOperationException("User not found");

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Phone = dto.Phone ?? "";

        await _unitOfWork.AppUsers.UpdateAsync(user);
        return MapToDto(user);
    }

    public async Task AddLoyaltyPointsAsync(long userId, int points)
    {
        var user = await _unitOfWork.AppUsers.GetByIdAsync(userId);
        if (user != null)
        {
            user.LoyaltyPoints += points;
            await _unitOfWork.AppUsers.UpdateAsync(user);
        }
    }

    // === Management Methods ===

    public async Task<List<UserManagementDto>> GetAllUsersAsync()
    {
        var users = await _unitOfWork.AppUsers.GetAllAsync();
        return users.Select(u => new UserManagementDto
        {
            AppUserId = u.AppUserId,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Phone = u.Phone,
            Email = u.Email,
            CustomerType = u.CustomerType,
            LoyaltyPoints = u.LoyaltyPoints,
            TotalSpent = u.TotalSpent,
            VisitCount = u.VisitCount,
            LastVisit = u.LastVisit,
            RegistrationDate = u.RegistrationDate,
            IsActive = u.IsActive,
            Notes = u.Notes,
            Roles = "No Roles" // Will be updated with actual roles
        }).ToList();
    }

    public async Task<UserDetailDto?> GetUserDetailAsync(long id)
    {
        var user = await _unitOfWork.AppUsers.GetByIdAsync(id);
        if (user == null) return null;

        var userRoles = (await _unitOfWork.UserRoles.FindAsync(ur => ur.UserId == id)).ToList();
        
        return new UserDetailDto
        {
            AppUserId = user.AppUserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = user.Phone,
            Email = user.Email,
            CustomerType = user.CustomerType,
            LoyaltyPoints = user.LoyaltyPoints,
            TotalSpent = user.TotalSpent,
            VisitCount = user.VisitCount,
            LastVisit = user.LastVisit,
            BirthDate = user.BirthDate,
            RegistrationDate = user.RegistrationDate,
            IsActive = user.IsActive,
            Notes = user.Notes,
            RoleIds = userRoles.Select(ur => ur.RoleId).ToList()
        };
    }

    public async Task<UserDetailDto> CreateUserAsync(UserDetailDto dto)
    {
        var user = new AppUser
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Phone = dto.Phone ?? "",
            Email = dto.Email,
            PasswordHash = HashPassword("DefaultPassword123!@#"),
            RegistrationDate = DateTime.UtcNow,
            CustomerType = dto.CustomerType ?? "Regular",
            LoyaltyPoints = dto.LoyaltyPoints,
            TotalSpent = dto.TotalSpent,
            VisitCount = dto.VisitCount,
            BirthDate = dto.BirthDate,
            IsActive = dto.IsActive,
            Notes = dto.Notes
        };

        await _unitOfWork.AppUsers.AddAsync(user);

        // Assign roles if provided
        if (dto.RoleIds.Any())
        {
            foreach (var roleId in dto.RoleIds)
            {
                var userRole = new UserRole
                {
                    UserId = user.AppUserId,
                    RoleId = roleId,
                    UserType = dto.CustomerType ?? "Regular"
                };
                await _unitOfWork.UserRoles.AddAsync(userRole);
            }
        }

        return await GetUserDetailAsync(user.AppUserId) ?? dto;
    }

    public async Task UpdateUserAsync(long id, UserDetailDto dto)
    {
        var user = await _unitOfWork.AppUsers.GetByIdAsync(id);
        if (user == null) throw new InvalidOperationException("User not found");

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Phone = dto.Phone ?? "";
        user.Email = dto.Email;
        user.CustomerType = dto.CustomerType;
        user.LoyaltyPoints = dto.LoyaltyPoints;
        user.TotalSpent = dto.TotalSpent;
        user.VisitCount = dto.VisitCount;
        user.BirthDate = dto.BirthDate;
        user.IsActive = dto.IsActive;
        user.Notes = dto.Notes;

        await _unitOfWork.AppUsers.UpdateAsync(user);

        // Update roles
        var currentRoles = (await _unitOfWork.UserRoles.FindAsync(ur => ur.UserId == id)).ToList();
        foreach (var role in currentRoles)
        {
            await _unitOfWork.UserRoles.DeleteAsync(role.Id);
        }

        foreach (var roleId in dto.RoleIds)
        {
            var userRole = new UserRole
            {
                UserId = id,
                RoleId = roleId,
                UserType = dto.CustomerType ?? "Regular"
            };
            await _unitOfWork.UserRoles.AddAsync(userRole);
        }
    }

    public async Task DeleteUserAsync(long id)
    {
        var user = await _unitOfWork.AppUsers.GetByIdAsync(id);
        if (user == null) throw new InvalidOperationException("User not found");

        // Remove user roles
        var userRoles = (await _unitOfWork.UserRoles.FindAsync(ur => ur.UserId == id)).ToList();
        foreach (var role in userRoles)
        {
            await _unitOfWork.UserRoles.DeleteAsync(role.Id);
        }

        await _unitOfWork.AppUsers.DeleteAsync(id);
    }

    public async Task<bool> DeactivateUserAsync(long id)
    {
        var user = await _unitOfWork.AppUsers.GetByIdAsync(id);
        if (user == null) return false;

        user.IsActive = false;
        await _unitOfWork.AppUsers.UpdateAsync(user);
        return true;
    }

    public async Task<bool> ActivateUserAsync(long id)
    {
        var user = await _unitOfWork.AppUsers.GetByIdAsync(id);
        if (user == null) return false;

        user.IsActive = true;
        await _unitOfWork.AppUsers.UpdateAsync(user);
        return true;
    }

    public async Task AssignRolesToUserAsync(long userId, List<long> roleIds)
    {
        // Remove existing roles
        var existingRoles = (await _unitOfWork.UserRoles.FindAsync(ur => ur.UserId == userId)).ToList();
        foreach (var role in existingRoles)
        {
            await _unitOfWork.UserRoles.DeleteAsync(role.Id);
        }

        // Add new roles
        var user = await _unitOfWork.AppUsers.GetByIdAsync(userId);
        if (user != null)
        {
            foreach (var roleId in roleIds)
            {
                var userRole = new UserRole
                {
                    UserId = userId,
                    RoleId = roleId,
                    UserType = user.CustomerType ?? "Regular"
                };
                await _unitOfWork.UserRoles.AddAsync(userRole);
            }
        }
    }

    public async Task<List<RoleDto>> GetAllRolesAsync()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();
        return roles.Where(r => r.IsActive).Select(r => new RoleDto
        {
            RoleId = r.RoleId,
            RoleName = r.RoleName,
            Description = r.Description,
            IsActive = r.IsActive,
            PermissionCount = 0,
            UserCount = 0
        }).ToList();
    }

    public async Task<RoleDto?> GetRoleByIdAsync(long id)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(id);
        if (role == null) return null;

        var permissions = (await _unitOfWork.RolePermissions.FindAsync(rp => rp.RoleId == id)).ToList();
        var users = (await _unitOfWork.UserRoles.FindAsync(ur => ur.RoleId == id)).ToList();

        return new RoleDto
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName,
            Description = role.Description,
            IsActive = role.IsActive,
            PermissionCount = permissions.Count,
            UserCount = users.Count,
            PermissionIds = permissions.Select(p => p.PermissionId).ToList()
        };
    }

    public async Task<RoleDto> CreateRoleAsync(RoleDto dto)
    {
        var role = new Role
        {
            RoleName = dto.RoleName,
            Description = dto.Description,
            IsActive = dto.IsActive
        };

        await _unitOfWork.Roles.AddAsync(role);
        return await GetRoleByIdAsync(role.RoleId) ?? dto;
    }

    public async Task UpdateRoleAsync(long id, RoleDto dto)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(id);
        if (role == null) throw new InvalidOperationException("Role not found");

        role.RoleName = dto.RoleName;
        role.Description = dto.Description;
        role.IsActive = dto.IsActive;

        await _unitOfWork.Roles.UpdateAsync(role);
    }

    public async Task DeleteRoleAsync(long id)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(id);
        if (role == null) throw new InvalidOperationException("Role not found");

        // Remove role permissions
        var rolePermissions = (await _unitOfWork.RolePermissions.FindAsync(rp => rp.RoleId == id)).ToList();
        foreach (var permission in rolePermissions)
        {
            await _unitOfWork.RolePermissions.DeleteAsync(permission.Id);
        }

        // Remove user roles
        var userRoles = (await _unitOfWork.UserRoles.FindAsync(ur => ur.RoleId == id)).ToList();
        foreach (var userRole in userRoles)
        {
            await _unitOfWork.UserRoles.DeleteAsync(userRole.Id);
        }

        await _unitOfWork.Roles.DeleteAsync(id);
    }

    public async Task AssignPermissionsToRoleAsync(long roleId, List<long> permissionIds)
    {
        // Remove existing permissions
        var existingPermissions = (await _unitOfWork.RolePermissions.FindAsync(rp => rp.RoleId == roleId)).ToList();
        foreach (var permission in existingPermissions)
        {
            await _unitOfWork.RolePermissions.DeleteAsync(permission.Id);
        }

        // Add new permissions
        foreach (var permissionId in permissionIds)
        {
            var rolePermission = new RolePermission
            {
                RoleId = roleId,
                PermissionId = permissionId
            };
            await _unitOfWork.RolePermissions.AddAsync(rolePermission);
        }
    }

    public async Task<List<PermissionDto>> GetAllPermissionsAsync()
    {
        var permissions = await _unitOfWork.Permissions.GetAllAsync();
        return permissions.Select(p => new PermissionDto
        {
            PermissionId = p.PermissionId,
            PermissionCode = p.PermissionCode,
            Description = p.Description,
            Category = p.Category
        }).ToList();
    }

    public async Task<ManagementSummaryDto> GetManagementSummaryAsync()
    {
        var users = await _unitOfWork.AppUsers.GetAllAsync();
        var roles = await _unitOfWork.Roles.GetAllAsync();
        var permissions = await _unitOfWork.Permissions.GetAllAsync();

        var today = DateTime.UtcNow.Date;
        var usersToday = users.Where(u => u.RegistrationDate.Date == today).Count();

        return new ManagementSummaryDto
        {
            TotalUsers = users.Count(),
            ActiveUsers = users.Count(u => u.IsActive),
            InactiveUsers = users.Count(u => !u.IsActive),
            TotalRoles = roles.Count(),
            TotalPermissions = permissions.Count(),
            ActiveRoles = roles.Count(r => r.IsActive),
            UsersToday = usersToday,
            TotalPurchases = users.Sum(u => u.TotalSpent)
        };
    }

    private string GenerateJwtToken(AppUser user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "resturantSecretKey2024VeryLongKeyForSecurity"));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.AppUserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim("UserType", user.CustomerType ?? "Customer")
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"] ?? "resturant",
            audience: _configuration["Jwt:Audience"] ?? "resturant",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(24),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private bool VerifyPassword(string password, string hash)
    {
        return HashPassword(password) == hash;
    }

    private UserDto MapToDto(AppUser user)
    {
        return new UserDto
        {
            AppUserId = user.AppUserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = user.Phone,
            Email = user.Email,
            RegistrationDate = user.RegistrationDate,
            LoyaltyPoints = user.LoyaltyPoints,
            TotalSpent = user.TotalSpent,
            VisitCount = user.VisitCount,
            LastVisit = user.LastVisit,
            IsActive = user.IsActive
        };
    }
}
