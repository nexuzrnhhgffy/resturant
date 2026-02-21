using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("branches")]
[MultilingualName("شعبه", "فرع")]
public class Branch : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long BranchId { get; set; }
    [MultilingualName("نام شعبه", "اسم الفرع")]
    public string? BranchName { get; set; }
    [MultilingualName("آدرس", "العنوان")]
    public string? Address { get; set; }
    [MultilingualName("تلفن", "رقم الهاتف")]
    public string? Phone { get; set; }
    [MultilingualName("ایمیل", "البريد الإلكتروني")]
    public string? Email { get; set; }
    [MultilingualName("شناسه مدیر", "معرف المدير")]
    public long? ManagerId { get; set; }
    [MultilingualName("ساعات کاری", "ساعات العمل")]
    public string? OpeningHours { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
}
