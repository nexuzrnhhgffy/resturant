using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("ads")]
[MultilingualName("تبلیغ", "إعلان")]
public class Ad : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long AdId { get; set; }
    [MultilingualName("شناسه مشتری", "معرف العميل")]
    public long ClientId { get; set; }
    [MultilingualName("عنوان تبلیغ", "عنوان الإعلان")]
    public string Title { get; set; }
    [MultilingualName("توضیحات", "الوصف")]
    public string Description { get; set; }
    [MultilingualName("نوع مدیا", "نوع الوسائط")]
    public string MediaType { get; set; }
    [MultilingualName("آدرس فایل", "رابط الملف")]
    public string FileUrl { get; set; }
    [MultilingualName("مدت نمایش (ثانیه)", "مدة العرض (ثانية)")]
    public int DurationSeconds { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
}
