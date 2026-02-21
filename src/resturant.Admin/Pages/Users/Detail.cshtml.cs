using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using resturant.Application.Services;
using resturant.Domain.DTOs;

namespace resturant.Admin.Pages.Users;

public class UserDetailModel : PageModel
{
    private readonly IUserService _userService;
    private readonly ILogger<UserDetailModel> _logger;

    [BindProperty]
    public new UserDetailDto User { get; set; } = new();

    public List<RoleDto> AvailableRoles { get; set; } = new();
    public bool IsNew { get; set; }

    public UserDetailModel(IUserService userService, ILogger<UserDetailModel> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync(long? id)
    {
        try
        {
            AvailableRoles = await _userService.GetAllRolesAsync();

            if (id.HasValue)
            {
                var userDetail = await _userService.GetUserDetailAsync(id.Value);
                if (userDetail == null)
                {
                    return NotFound();
                }
                User = userDetail;
                IsNew = false;
            }
            else
            {
                User.IsActive = true;
                IsNew = true;
            }

            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading user detail");
            TempData["Error"] = "خطا در بارگیری داده‌های کاربر";
            return RedirectToPage("/Users/Index");
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            AvailableRoles = await _userService.GetAllRolesAsync();
            return Page();
        }

        try
        {
            // Get selected roles from form
            var selectedRoles = Request.Form["selectedRoles"].Where(r => !string.IsNullOrEmpty(r)).ToList();
            User.RoleIds = selectedRoles.Select(r => long.Parse(r ?? "0")).ToList();

            if (User.AppUserId == 0)
            {
                await _userService.CreateUserAsync(User);
                TempData["Success"] = "کاربر با موفقیت ایجاد شد";
            }
            else
            {
                await _userService.UpdateUserAsync(User.AppUserId, User);
                TempData["Success"] = "کاربر با موفقیت به‌روز شد";
            }

            return RedirectToPage("/Users/Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving user");
            TempData["Error"] = "خطا در ذخیره‌سازی کاربر";
            AvailableRoles = await _userService.GetAllRolesAsync();
            return Page();
        }
    }
}
