using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using resturant.Application.Services;
using resturant.Domain.DTOs;

namespace resturant.Admin.Pages.Roles;

public class RolesIndexModel : PageModel
{
    private readonly IUserService _userService;
    private readonly ILogger<RolesIndexModel> _logger;

    public List<RoleDto> Roles { get; set; } = new();

    public RolesIndexModel(IUserService userService, ILogger<RolesIndexModel> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        try
        {
            Roles = await _userService.GetAllRolesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading roles");
            TempData["Error"] = "خطا در بارگیری نقش‌ها";
        }
    }

    public async Task<IActionResult> OnPostSaveRoleAsync(long roleId, string roleName, string roleDescription, bool roleIsActive)
    {
        try
        {
            var roleDto = new RoleDto
            {
                RoleId = roleId,
                RoleName = roleName,
                Description = roleDescription,
                IsActive = roleIsActive
            };

            if (roleId == 0)
            {
                await _userService.CreateRoleAsync(roleDto);
                TempData["Success"] = "نقش با موفقیت ایجاد شد";
            }
            else
            {
                await _userService.UpdateRoleAsync(roleId, roleDto);
                TempData["Success"] = "نقش با موفقیت به‌روز شد";
            }

            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving role");
            TempData["Error"] = "خطا در ذخیره‌سازی نقش";
            return RedirectToPage();
        }
    }

    public async Task<IActionResult> OnPostSavePermissionsAsync(long roleId, List<long> permissions)
    {
        try
        {
            await _userService.AssignPermissionsToRoleAsync(roleId, permissions ?? new());
            TempData["Success"] = "دسترسی‌ها با موفقیت به‌روز شدند";
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving permissions");
            TempData["Error"] = "خطا در ذخیره‌سازی دسترسی‌ها";
            return RedirectToPage();
        }
    }
}
