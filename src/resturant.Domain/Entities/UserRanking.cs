using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("user_rankings")]
[MultilingualName("رتبه کاربر", "تصنيف المستخدم")]
public class UserRanking : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long RankingId { get; set; }
    [MultilingualName("شناسه کاربر", "معرف المستخدم")]
    public long AppUserId { get; set; }
    [MultilingualName("سطح رتبه", "مستوى التصنيف")]
    public string? RankLevel { get; set; }
    [MultilingualName("کل امتیاز", "إجمالي النقاط")]
    public int TotalPoints { get; set; }
    [MultilingualName("تعداد بازدید", "عدد الزيارات")]
    public int VisitsCount { get; set; }
    [MultilingualName("میانگین خرید", "متوسط الإنفاق")]
    public decimal AverageSpent { get; set; }
    [MultilingualName("آخر بازدید", "آخر زيارة")]
    public DateTime? LastVisitDate { get; set; }
    [MultilingualName("مزایا", "الفوائد")]
    public string? Benefits { get; set; }
    [MultilingualName("از تاریخ", "منذ التاريخ")]
    public DateTime RankSince { get; set; }
}
