using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using resturant.Application.Services;
using resturant.Domain.DTOs;

namespace resturant.Admin.Pages.Management;

public class ManagementIndexModel : PageModel
{
    private readonly IUserService _userService;
    private readonly ILogger<ManagementIndexModel> _logger;

    public ManagementSummaryDto Summary { get; set; } = new();

    public ManagementIndexModel(IUserService userService, ILogger<ManagementIndexModel> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        try
        {
            Summary = await _userService.GetManagementSummaryAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading management summary");
        }
    }
}
