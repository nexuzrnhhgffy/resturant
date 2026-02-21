using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("payments")]
[MultilingualName("پرداخت", "الدفع")]
public class Payment : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long PaymentId { get; set; }
    [MultilingualName("شناسه سفارش", "معرف الطلب")]
    public long OrderId { get; set; }
    [MultilingualName("شناسه کاربر", "معرف المستخدم")]
    public long AppUserId { get; set; }
    [MultilingualName("روش پرداخت", "طريقة الدفع")]
    public string PaymentMethod { get; set; }
    [MultilingualName("مبلغ", "المبلغ")]
    public decimal Amount { get; set; }
    [MultilingualName("انعام", "بقشيش")]
    public decimal TipAmount { get; set; }
    [MultilingualName("تراکنش آی دی", "رقم المعاملة")]
    public string TransactionId { get; set; }
    [MultilingualName("وضعیت پرداخت", "حالة الدفع")]
    public string PaymentStatus { get; set; }
    [MultilingualName("زمان پرداخت", "وقت الدفع")]
    public DateTime PaidAt { get; set; }
    [MultilingualName("پردازنده", "تمت المعالجة بواسطة")]
    public long? ProcessedBy { get; set; }
    [MultilingualName("یادداشت", "ملاحظات")]
    public string Notes { get; set; }
}
