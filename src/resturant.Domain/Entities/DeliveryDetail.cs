using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("delivery_details")]
[MultilingualName("جزئیات پیک", "تفاصيل التوصيل")]
public class DeliveryDetail : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long DeliveryId { get; set; }
    [MultilingualName("شناسه سفارش", "معرف الطلب")]
    public long OrderId { get; set; }
    [MultilingualName("شناسه راننده", "معرف السائق")]
    public long? DriverId { get; set; }
    [MultilingualName("وضعیت تحویل", "حالة التوصيل")]
    public string DeliveryStatus { get; set; }
    [MultilingualName("هزینه پیک", "رسوم التوصيل")]
    public decimal DeliveryFee { get; set; }
    [MultilingualName("زمان تخمینی", "وقت التسليم المقدر")]
    public DateTime EstimatedDeliveryTime { get; set; }
    [MultilingualName("زمان واقعی", "وقت التسليم الفعلي")]
    public DateTime? ActualDeliveryTime { get; set; }
    [MultilingualName("فاصله (کیلومتر)", "المسافة (كم)")]
    public decimal DistanceKm { get; set; }
}
