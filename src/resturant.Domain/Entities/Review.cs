using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("reviews")]
[MultilingualName("نظر سنجی", "مراجعة")]
public class Review : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long ReviewId { get; set; }
    [MultilingualName("شناسه سفارش", "معرف الطلب")]
    public long OrderId { get; set; }
    [MultilingualName("شناسه کاربر", "معرف المستخدم")]
    public long AppUserId { get; set; }
    [MultilingualName("شناسه آیتم منو", "معرف عنصر القائمة")]
    public long? MenuItemId { get; set; }
    [MultilingualName("امتیاز", "التقييم")]
    public int Rating { get; set; }
    [MultilingualName("نظر", "تعليق")]
    public string Comment { get; set; }
    [MultilingualName("تایید شده", "موافق عليه")]
    public bool IsApproved { get; set; }
}
