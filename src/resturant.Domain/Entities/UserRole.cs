using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("user_roles")]
[MultilingualName("نقش کاربر", "دور المستخدم")]
public class UserRole : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public new long Id { get; set; }
    [MultilingualName("نوع کاربر", "نوع المستخدم")]
    public string? UserType { get; set; }
    [MultilingualName("شناسه کاربر", "معرف المستخدم")]
    public long UserId { get; set; }
    [MultilingualName("شناسه نقش", "معرف الدور")]
    public long RoleId { get; set; }
}
