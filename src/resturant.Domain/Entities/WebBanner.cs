using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("web_banners")]
[MultilingualName("بنرهای وب", "لافتات الويب")]
public class WebBanner : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long BannerId { get; set; }
    [MultilingualName("عنوان", "العنوان")]
    public string? Title { get; set; }
    [MultilingualName("تصویر", "الصورة")]
    public string? ImageUrl { get; set; }
    [MultilingualName("لینک", "الرابط")]
    public string? LinkUrl { get; set; }
    [MultilingualName("موقعیت", "الموقع")]
    public string? Position { get; set; }
    [MultilingualName("ترتیب نمایش", "ترتيب العرض")]
    public int DisplayOrder { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
    [MultilingualName("شروع", "تبدأ")]
    public DateTime StartsAt { get; set; }
    [MultilingualName("پایان", "تنتهي")]
    public DateTime ExpiresAt { get; set; }
}
