using Microsoft.AspNetCore.Mvc.RazorPages;
using resturant.Application.Services;
using resturant.Domain.DTOs;

namespace resturant.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IMenuService _menuService;
    
    public IEnumerable<MenuItemDto> PopularItems { get; set; } = new List<MenuItemDto>();

    public IndexModel(IMenuService menuService)
    {
        _menuService = menuService;
    }

    public async Task OnGetAsync()
    {
        PopularItems = await _menuService.GetPopularItemsAsync(8);
    }
}
