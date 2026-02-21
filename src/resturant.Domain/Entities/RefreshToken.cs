using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("refresh_tokens")]
[MultilingualName("توکن های رفرش", "رموز التحديث")]
public class RefreshToken : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long RefreshTokenId { get; set; }
    [MultilingualName("توکن", "الرمز")]
    public string Token { get; set; }
    [MultilingualName("نوع کاربر", "نوع المستخدم")]
    public string UserType { get; set; }
    [MultilingualName("شناسه کاربر", "معرف المستخدم")]
    public long UserId { get; set; }
    [MultilingualName("تاریخ انقضا", "تاريخ الانتهاء")]
    public DateTime ExpiresAt { get; set; }
    [MultilingualName("تاریخ ابطال", "تاريخ الإبطال")]
    public DateTime? RevokedAt { get; set; }
    [MultilingualName("آی‌پی", "عنوان IP")]
    public string IpAddress { get; set; }
    [MultilingualName("مرورگر", "المتصفح")]
    public string UserAgent { get; set; }
}
