using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("user_activity_logs")]
[MultilingualName("لاگ فعالیت کاربر", "سجل نشاط المستخدم")]
public class UserActivityLog : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long LogId { get; set; }
    [MultilingualName("نوع کاربر", "نوع المستخدم")]
    public string UserType { get; set; }
    [MultilingualName("شناسه کاربر", "معرف المستخدم")]
    public long UserId { get; set; }
    [MultilingualName("نوع عملیات", "نوع الإجراء")]
    public string ActionType { get; set; }
    [MultilingualName("آی‌پی", "عنوان IP")]
    public string IpAddress { get; set; }
    [MultilingualName("مرورگر", "المتصفح")]
    public string UserAgent { get; set; }
    [MultilingualName("توضیحات", "الوصف")]
    public string Description { get; set; }
}
