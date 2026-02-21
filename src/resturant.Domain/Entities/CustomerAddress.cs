using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("app_user_addresses")]
[MultilingualName("آدرس کاربر", "عنوان المستخدم")]
public class CustomerAddress : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long AddressId { get; set; }
    [MultilingualName("شناسه کاربر", "معرف المستخدم")]
    public long AppUserId { get; set; }
    [MultilingualName("عنوان", "العنوان")]
    public string Title { get; set; }
    [MultilingualName("آدرس کامل", "العنوان الكامل")]
    public string Address { get; set; }
    [MultilingualName("عرض جغرافیایی", "خط العرض")]
    public decimal Latitude { get; set; }
    [MultilingualName("طول جغرافیایی", "خط الطول")]
    public decimal Longitude { get; set; }
    [MultilingualName("پیش فرض", "افتراضي")]
    public bool IsDefault { get; set; }
}
