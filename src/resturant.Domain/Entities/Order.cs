using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("orders")]
[MultilingualName("سفارش", "الطلب")]
public class Order : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long OrderId { get; set; }
    [MultilingualName("شناسه کاربر", "معرف المستخدم")]
    public long AppUserId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("شناسه میز", "معرف الطاولة")]
    public long? TableId { get; set; }
    [MultilingualName("شناسه تبلت", "معرف التابلت")]
    public long? TabletId { get; set; }
    [MultilingualName("نوع سفارش", "نوع الطلب")]
    public string? OrderType { get; set; }
    [MultilingualName("منبع سفارش", "مصدر الطلب")]
    public string? OrderSource { get; set; }
    [MultilingualName("جمع کل", "المجموع الكلي")]
    public decimal TotalAmount { get; set; }
    [MultilingualName("تخفیف", "الخصم")]
    public decimal DiscountAmount { get; set; }
    [MultilingualName("مالیات", "الضريبة")]
    public decimal TaxAmount { get; set; }
    [MultilingualName("سرویس", "رسوم الخدمة")]
    public decimal ServiceCharge { get; set; }
    [MultilingualName("مبلغ نهایی", "المبلغ النهائي")]
    public decimal FinalAmount { get; set; }
    [MultilingualName("وضعیت سفارش", "حالة الطلب")]
    public Domain.Enums.OrderStatus OrderStatus { get; set; }
    [MultilingualName("تاریخ سفارش", "تاريخ الطلب")]
    public DateTime OrderDate { get; set; }
    [MultilingualName("زمان برآورد شده", "الوقت المقدر")]
    public int EstimatedTime { get; set; }
    [MultilingualName("زمان واقعی", "الوقت الفعلي")]
    public int ActualPrepTime { get; set; }
    [MultilingualName("توضیحات", "ملاحظات")]
    public string? Notes { get; set; }
    [MultilingualName("پرداخت شده", "مدفوع")]
    public bool IsPaid { get; set; }
}
