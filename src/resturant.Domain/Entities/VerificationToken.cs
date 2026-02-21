using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("verification_tokens")]
[MultilingualName("توکن های تایید", "رموز التحقق")]
public class VerificationToken : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long TokenId { get; set; }
    [MultilingualName("نوع کاربر", "نوع المستخدم")]
    public string? UserType { get; set; }
    [MultilingualName("شناسه کاربر", "معرف المستخدم")]
    public long UserId { get; set; }
    [MultilingualName("کد تایید", "رمز التحقق")]
    public string? TokenCode { get; set; }
    [MultilingualName("هدف", "الغرض")]
    public string? Purpose { get; set; }
    [MultilingualName("تاریخ انقضا", "تاريخ الانتهاء")]
    public DateTime ExpiresAt { get; set; }
    [MultilingualName("استفاده شده", "مستخدم")]
    public bool IsUsed { get; set; }
    [MultilingualName("تعداد تلاش", "عدد المحاولات")]
    public int AttemptsCount { get; set; }
}
