using Microsoft.EntityFrameworkCore;
using resturant.Domain.DTOs;
using resturant.Domain.Entities;
using resturant.Domain.Interfaces;

namespace resturant.Application.Services;

public interface IMenuService
{
    Task<MenuWithCategoriesDto> GetMenuAsync(long? branchId = null);
    Task<MenuItemDto?> GetMenuItemAsync(long id);
    Task<IEnumerable<MenuCategoryDto>> GetCategoriesAsync(long? branchId = null);
    Task<IEnumerable<MenuItemDto>> GetPopularItemsAsync(int count = 10);
}

public class MenuService : IMenuService
{
    private readonly IUnitOfWork _unitOfWork;

    public MenuService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MenuWithCategoriesDto> GetMenuAsync(long? branchId = null)
    {
        var categories = await GetCategoriesAsync(branchId);
        var popularItems = await GetPopularItemsAsync(10);

        return new MenuWithCategoriesDto
        {
            Categories = categories.ToList(),
            PopularItems = popularItems.ToList()
        };
    }

    public async Task<MenuItemDto?> GetMenuItemAsync(long id)
    {
        var item = (await _unitOfWork.MenuItems.FindAsync(m => m.MenuItemId == id)).FirstOrDefault();
        if (item == null) return null;

        var category = (await _unitOfWork.MenuCategories.FindAsync(c => c.CategoryId == item.CategoryId)).FirstOrDefault();

        return new MenuItemDto
        {
            MenuItemId = item.MenuItemId,
            CategoryId = item.CategoryId,
            CategoryName = category?.Name,
            ItemName = item.ItemName,
            Description = item.Description,
            Price = item.Price,
            Cost = item.Cost,
            IsAvailable = item.IsAvailable,
            PreparationTime = item.PreparationTime,
            Calories = item.Calories,
            Allergens = item.Allergens,
            Tags = item.Tags,
            ImageUrl = item.ImageUrl,
            DisplayOrder = item.DisplayOrder,
            PopularityScore = item.PopularityScore
        };
    }

    public async Task<IEnumerable<MenuCategoryDto>> GetCategoriesAsync(long? branchId = null)
    {
        var categories = await _unitOfWork.MenuCategories.GetAllAsync();
        
        if (branchId.HasValue)
        {
            categories = categories.Where(c => c.BranchId == branchId.Value || c.BranchId == 0);
        }

        var result = new List<MenuCategoryDto>();
        foreach (var category in categories.Where(c => c.IsActive && c.ParentCategoryId == null).OrderBy(c => c.DisplayOrder))
        {
            result.Add(await MapCategoryToDto(category));
        }

        return result;
    }

    public async Task<IEnumerable<MenuItemDto>> GetPopularItemsAsync(int count = 10)
    {
        var items = await _unitOfWork.MenuItems.GetAllAsync();
        
        return items
            .Where(m => m.IsAvailable)
            .OrderByDescending(m => m.PopularityScore)
            .Take(count)
            .Select(m => new MenuItemDto
            {
                MenuItemId = m.MenuItemId,
                CategoryId = m.CategoryId,
                ItemName = m.ItemName,
                Description = m.Description,
                Price = m.Price,
                ImageUrl = m.ImageUrl,
                PopularityScore = m.PopularityScore
            });
    }

    private async Task<MenuCategoryDto> MapCategoryToDto(MenuCategory category)
    {
        var items = await _unitOfWork.MenuItems.FindAsync(m => m.CategoryId == category.CategoryId && m.IsAvailable);
        var subCategories = await _unitOfWork.MenuCategories.FindAsync(c => c.ParentCategoryId == category.CategoryId && c.IsActive);

        return new MenuCategoryDto
        {
            CategoryId = category.CategoryId,
            ParentCategoryId = category.ParentCategoryId,
            Name = category.Name,
            Description = category.Description,
            ImageUrl = category.ImageUrl,
            DisplayOrder = category.DisplayOrder,
            IsActive = category.IsActive,
            Items = items
                .OrderBy(m => m.DisplayOrder)
                .Select(m => new MenuItemDto
                {
                    MenuItemId = m.MenuItemId,
                    CategoryId = m.CategoryId,
                    ItemName = m.ItemName,
                    Description = m.Description,
                    Price = m.Price,
                    ImageUrl = m.ImageUrl,
                    IsAvailable = m.IsAvailable,
                    PopularityScore = m.PopularityScore
                }).ToList(),
            SubCategories = subCategories
                .OrderBy(c => c.DisplayOrder)
                .Select(c => MapCategoryToDto(c).Result).ToList()
        };
    }
}
