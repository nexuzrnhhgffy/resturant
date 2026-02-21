using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("reservations")]
[MultilingualName("رزرو", "الحجز")]
public class Reservation : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long ReservationId { get; set; }
    [MultilingualName("شناسه کاربر", "معرف المستخدم")]
    public long AppUserId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("شناسه میز", "معرف الطاولة")]
    public long TableId { get; set; }
    [MultilingualName("تاریخ رزرو", "تاريخ الحجز")]
    public DateTime ReservationDate { get; set; }
    [MultilingualName("ساعت رزرو", "وقت الحجز")]
    public TimeSpan ReservationTime { get; set; }
    [MultilingualName("تعداد نفرات", "عدد الأشخاص")]
    public int PartySize { get; set; }
    [MultilingualName("نوع رزرو", "نوع الحجز")]
    public string ReservationType { get; set; }
    [MultilingualName("وضعیت", "الحالة")]
    public string Status { get; set; }
    [MultilingualName("درخواست خاص", "طلبات خاصة")]
    public string SpecialRequests { get; set; }
    [MultilingualName("دلیل کنسل", "سبب الإلغاء")]
    public string CancellationReason { get; set; }
    [MultilingualName("تایید کننده", "تم التأكيد بواسطة")]
    public long? ConfirmedBy { get; set; }
}
