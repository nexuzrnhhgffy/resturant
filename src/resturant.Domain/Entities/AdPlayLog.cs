using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("ad_play_logs")]
[MultilingualName("گزارش پخش تبلیغ", "سجل تشغيل الإعلان")]
public class AdPlayLog : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long LogId { get; set; }
    [MultilingualName("شناسه کمپین", "معرف الحملة")]
    public long CampaignId { get; set; }
    [MultilingualName("زمان پخش", "وقت التشغيل")]
    public DateTime PlayedAt { get; set; }
    [MultilingualName("مدت پخش شده", "المدة المشغلة")]
    public int DurationPlayed { get; set; }
}
