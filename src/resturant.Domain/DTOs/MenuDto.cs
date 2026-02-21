using System;

namespace resturant.Domain.DTOs;

public class MenuItemDto
{
    public long MenuItemId { get; set; }
    public long CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal Cost { get; set; }
    public bool IsAvailable { get; set; }
    public int? PreparationTime { get; set; }
    public int? Calories { get; set; }
    public string? Allergens { get; set; }
    public string? Tags { get; set; }
    public string? ImageUrl { get; set; }
    public int DisplayOrder { get; set; }
    public int PopularityScore { get; set; }
}

public class MenuCategoryDto
{
    public long CategoryId { get; set; }
    public long? ParentCategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }
    public List<MenuItemDto> Items { get; set; } = new();
    public List<MenuCategoryDto> SubCategories { get; set; } = new();
}

public class MenuWithCategoriesDto
{
    public List<MenuCategoryDto> Categories { get; set; } = new();
    public List<MenuItemDto> PopularItems { get; set; } = new();
}
