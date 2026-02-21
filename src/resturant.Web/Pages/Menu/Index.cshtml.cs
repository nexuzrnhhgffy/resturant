using Microsoft.AspNetCore.Mvc.RazorPages;
using resturant.Application.Services;
using resturant.Domain.DTOs;

namespace resturant.Web.Pages.Menu;

public class IndexModel : PageModel
{
    private readonly IMenuService _menuService;
    
    public IEnumerable<MenuCategoryDto> Categories { get; set; } = new List<MenuCategoryDto>();

    public IndexModel(IMenuService menuService)
    {
        _menuService = menuService;
    }

    public async Task OnGetAsync()
    {
        Categories = await _menuService.GetCategoriesAsync();
    }
}
