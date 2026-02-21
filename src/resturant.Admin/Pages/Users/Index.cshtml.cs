using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using resturant.Application.Services;
using resturant.Domain.DTOs;

namespace resturant.Admin.Pages.Users;

public class UsersIndexModel : PageModel
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersIndexModel> _logger;

    public List<UserManagementDto> Users { get; set; } = new();

    public UsersIndexModel(IUserService userService, ILogger<UsersIndexModel> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        try
        {
            Users = await _userService.GetAllUsersAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading users");
            TempData["Error"] = "خطا در بارگیری کاربران";
        }
    }
}
