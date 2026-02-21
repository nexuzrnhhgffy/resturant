using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("site_settings")]
[MultilingualName("تنظیمات سایت", "إعدادات الموقع")]
public class SiteSetting : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long SettingId { get; set; }
    [MultilingualName("کلید تنظیم", "مفتاح الإعداد")]
    public string SettingKey { get; set; }
    [MultilingualName("مقدار", "القيمة")]
    public string SettingValue { get; set; }
    [MultilingualName("نوع داده", "نوع البيانات")]
    public string DataType { get; set; }
    [MultilingualName("دسته بندی", "الفئة")]
    public string Category { get; set; }
}
