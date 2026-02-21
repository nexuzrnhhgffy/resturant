using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("ad_clients")]
[MultilingualName("مشتری تبلیغاتی", "عميل الإعلانات")]
public class AdClient : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long ClientId { get; set; }
    [MultilingualName("نام شرکت", "اسم الشركة")]
    public string? CompanyName { get; set; }
    [MultilingualName("شخص تماس", "شخص الاتصال")]
    public string? ContactPerson { get; set; }
    [MultilingualName("تلفن", "رقم الهاتف")]
    public string? Phone { get; set; }
    [MultilingualName("ایمیل", "البريد الإلكتروني")]
    public string? Email { get; set; }
    [MultilingualName("آدرس", "العنوان")]
    public string? Address { get; set; }
}
