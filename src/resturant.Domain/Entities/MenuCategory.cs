using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("menu_categories")]
[MultilingualName("دسته منو", "فئة القائمة")]
public class MenuCategory : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long CategoryId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("شناسه والد", "معرف الوالدين")]
    public long? ParentCategoryId { get; set; }
    [MultilingualName("نام", "الاسم")]
    public string? Name { get; set; }
    [MultilingualName("توضیحات", "الوصف")]
    public string? Description { get; set; }
    [MultilingualName("تصویر", "الصورة")]
    public string? ImageUrl { get; set; }
    [MultilingualName("ترتیب نمایش", "ترتيب العرض")]
    public int DisplayOrder { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
}
