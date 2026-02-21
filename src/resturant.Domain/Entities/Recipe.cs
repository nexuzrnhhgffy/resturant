using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("recipes")]
[MultilingualName("دستور پخت", "الوصفة")]
public class Recipe : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long RecipeId { get; set; }
    [MultilingualName("شناسه آیتم منو", "معرف عنصر القائمة")]
    public long MenuItemId { get; set; }
    [MultilingualName("شناسه انبار", "معرف المخزون")]
    public long InventoryId { get; set; }
    [MultilingualName("مقدار", "الكمية")]
    public decimal Quantity { get; set; }
    [MultilingualName("نوع واحد", "نوع الوحدة")]
    public string? UnitType { get; set; }
}
