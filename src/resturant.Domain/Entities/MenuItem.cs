using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("menu_items")]
[MultilingualName("آیتم منو", "عنصر القائمة")]
public class MenuItem : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long MenuItemId { get; set; }
    [MultilingualName("شناسه دسته", "معرف الفئة")]
    public long CategoryId { get; set; }
    [MultilingualName("نام کالا", "اسم العنصر")]
    public string ItemName { get; set; }
    [MultilingualName("توضیحات", "الوصف")]
    public string Description { get; set; }
    [MultilingualName("قیمت", "السعر")]
    public decimal Price { get; set; }
    [MultilingualName("قیمت تمام شده", "التكلفة")]
    public decimal Cost { get; set; }
    [MultilingualName("موجود", "متاح")]
    public bool IsAvailable { get; set; }
    [MultilingualName("زمان آماده سازی", "وقت التحضير")]
    public int PreparationTime { get; set; }
    [MultilingualName("کالری", "سعرات حرارية")]
    public int Calories { get; set; }
    [MultilingualName("آلرژی", "مسببات الحساسية")]
    public string Allergens { get; set; }
    [MultilingualName("برچسب ها", "العلامات")]
    public string Tags { get; set; }
    [MultilingualName("تصویر", "الصورة")]
    public string ImageUrl { get; set; }
    [MultilingualName("ترتیب", "الترتيب")]
    public int DisplayOrder { get; set; }
    [MultilingualName("امتیاز محبوبیت", "درجة الشعبية")]
    public int PopularityScore { get; set; }
}
