using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using resturant.Application.Services;
using resturant.Domain.DTOs;

namespace resturant.Admin.Pages.Permissions;

public class PermissionsIndexModel : PageModel
{
    private readonly IUserService _userService;
    private readonly ILogger<PermissionsIndexModel> _logger;

    public List<PermissionDto> Permissions { get; set; } = new();

    public PermissionsIndexModel(IUserService userService, ILogger<PermissionsIndexModel> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        try
        {
            Permissions = await _userService.GetAllPermissionsAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading permissions");
            TempData["Error"] = "خطا در بارگیری دسترسی‌ها";
        }
    }
}
