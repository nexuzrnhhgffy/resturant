using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("employees")]
[MultilingualName("پروفایل کارمند", "ملف الموظف")]
public class Employee : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long EmployeeId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("شناسه کاربر", "معرف المستخدم")]
    public long AppUserId { get; set; }
    [MultilingualName("کد پرسنلی", "رمز الموظف")]
    public string EmployeeCode { get; set; }
    [MultilingualName("نقش", "الدور")]
    public string Role { get; set; }
    [MultilingualName("حقوق", "الراتب")]
    public decimal Salary { get; set; }
    [MultilingualName("تاریخ استخدام", "تاريخ التوظيف")]
    public DateTime HireDate { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
    [MultilingualName("دسترسی ها", "الأذونات")]
    public string Permissions { get; set; }
}
