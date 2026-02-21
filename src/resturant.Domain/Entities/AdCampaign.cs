using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("ad_campaigns")]
[MultilingualName("کمپین تبلیغاتی", "حملة إعلانية")]
public class AdCampaign : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long CampaignId { get; set; }
    [MultilingualName("شناسه تبلیغ", "معرف الإعلان")]
    public long AdId { get; set; }
    [MultilingualName("شناسه مانیتور", "معرف الشاشة")]
    public long ScreenId { get; set; }
    [MultilingualName("تاریخ شروع", "تاريخ البدء")]
    public DateTime StartDate { get; set; }
    [MultilingualName("تاریخ پایان", "تاريخ النهاية")]
    public DateTime EndDate { get; set; }
    [MultilingualName("هزینه کل", "التكلفة الإجمالية")]
    public decimal TotalCost { get; set; }
    [MultilingualName("وضعیت پرداخت", "حالة الدفع")]
    public string? PaymentStatus { get; set; }
    [MultilingualName("اولویت", "الأولوية")]
    public int Priority { get; set; }
    [MultilingualName("حداکثر پخش", "الحد الأقصى للتشغيل")]
    public int PlayCountLimit { get; set; }
    [MultilingualName("پخش شده", "تم التشغيل")]
    public int CurrentPlays { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
}
