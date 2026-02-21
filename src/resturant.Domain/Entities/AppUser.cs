using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("app_users")]
[MultilingualName("کاربر", "المستخدم")]
public class AppUser : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long AppUserId { get; set; }
    [MultilingualName("نام", "الاسم الأول")]
    public string FirstName { get; set; }
    [MultilingualName("نام خانوادگی", "اسم العائلة")]
    public string LastName { get; set; }
    [MultilingualName("تلفن", "رقم الهاتف")]
    public string Phone { get; set; }
    [MultilingualName("ایمیل", "البريد الإلكتروني")]
    public string Email { get; set; }
    [MultilingualName("هش پسورد", "تجزئة كلمة المرور")]
    public string PasswordHash { get; set; }
    [MultilingualName("تاریخ ثبت نام", "تاريخ التسجيل")]
    public DateTime RegistrationDate { get; set; }
    [MultilingualName("نوع مشتری", "نوع العميل")]
    public string CustomerType { get; set; }
    [MultilingualName("امتیاز وفاداری", "نقاط الولاء")]
    public int LoyaltyPoints { get; set; }
    [MultilingualName("کل خرید", "إجمالي الإنفاق")]
    public decimal TotalSpent { get; set; }
    [MultilingualName("تعداد بازدید", "عدد الزيارات")]
    public int VisitCount { get; set; }
    [MultilingualName("آخرین بازدید", "آخر زيارة")]
    public DateTime? LastVisit { get; set; }
    [MultilingualName("تاریخ تولد", "تاريخ الميلاد")]
    public DateTime? BirthDate { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
    [MultilingualName("یادداشت", "ملاحظات")]
    public string Notes { get; set; }
}
