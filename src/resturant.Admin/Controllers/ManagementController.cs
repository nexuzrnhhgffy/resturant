using Microsoft.AspNetCore.Mvc;
using resturant.Application.Services;
using resturant.Domain.DTOs;

namespace resturant.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserService userService, ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
        try
        {
            await _userService.DeleteUserAsync(id);
            return Ok(new { message = "کاربر با موفقیت حذف شد" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting user");
            return BadRequest(new { message = "خطا در حذف کاربر" });
        }
    }

    [HttpPost("{id}/deactivate")]
    public async Task<IActionResult> DeactivateUser(long id)
    {
        try
        {
            var result = await _userService.DeactivateUserAsync(id);
            if (result)
            {
                return Ok(new { message = "کاربر با موفقیت غیرفعال شد" });
            }
            return NotFound(new { message = "کاربر یافت نشد" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deactivating user");
            return BadRequest(new { message = "خطا در غیرفعال کردن کاربر" });
        }
    }

    [HttpPost("{id}/activate")]
    public async Task<IActionResult> ActivateUser(long id)
    {
        try
        {
            var result = await _userService.ActivateUserAsync(id);
            if (result)
            {
                return Ok(new { message = "کاربر با موفقیت فعال شد" });
            }
            return NotFound(new { message = "کاربر یافت نشد" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error activating user");
            return BadRequest(new { message = "خطا در فعال کردن کاربر" });
        }
    }
}

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<RolesController> _logger;

    public RolesController(IUserService userService, ILogger<RolesController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRole(long id)
    {
        try
        {
            var role = await _userService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting role");
            return BadRequest();
        }
    }

    [HttpGet("{roleId}/permissions")]
    public async Task<IActionResult> GetRolePermissions(long roleId)
    {
        try
        {
            var permissions = await _userService.GetAllPermissionsAsync();
            return Ok(permissions);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting permissions");
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(long id)
    {
        try
        {
            await _userService.DeleteRoleAsync(id);
            return Ok(new { message = "نقش با موفقیت حذف شد" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting role");
            return BadRequest(new { message = "خطا در حذف نقش" });
        }
    }
}

[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<PermissionsController> _logger;

    public PermissionsController(IUserService userService, ILogger<PermissionsController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPermissions()
    {
        try
        {
            var permissions = await _userService.GetAllPermissionsAsync();
            return Ok(permissions);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting permissions");
            return BadRequest();
        }
    }
}
