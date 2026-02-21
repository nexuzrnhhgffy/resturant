using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("screens")]
[MultilingualName("مانیتور", "شاشة")]
public class Screen : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long ScreenId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("نام مانیتور", "اسم الشاشة")]
    public string ScreenName { get; set; }
    [MultilingualName("موقعیت", "الموقع")]
    public string LocationDescription { get; set; }
    [MultilingualName("آی‌پی", "عنوان IP")]
    public string IpAddress { get; set; }
    [MultilingualName("رزولوشن", "الدقة")]
    public string Resolution { get; set; }
    [MultilingualName("جهت", "الاتجاه")]
    public string Orientation { get; set; }
    [MultilingualName("وضعیت", "الحالة")]
    public string Status { get; set; }
    [MultilingualName("مک آدرس", "مك")]
    public string MacAddress { get; set; }
    [MultilingualName("زمان آنلاین بودن", "آنلاین")]
    public string LastHeartbeat { get; set; }
}
