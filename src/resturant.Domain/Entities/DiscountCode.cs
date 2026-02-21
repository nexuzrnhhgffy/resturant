using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("discount_codes")]
[MultilingualName("کد تخفیف", "رمز الخصم")]
public class DiscountCode : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long CodeId { get; set; }
    [MultilingualName("کد", "الرمز")]
    public string? Code { get; set; }
    [MultilingualName("نوع تخفیف", "نوع الخصم")]
    public string? DiscountType { get; set; }
    [MultilingualName("مقدار", "القيمة")]
    public decimal Value { get; set; }
    [MultilingualName("حداکثر استفاده", "الحد الأقصى للاستخدام")]
    public int MaxUsage { get; set; }
    [MultilingualName("تعداد استفاده شده", "عدد مرات الاستخدام")]
    public int UsedCount { get; set; }
    [MultilingualName("تاریخ انقضا", "تاريخ الانتهاء")]
    public DateTime ExpiryDate { get; set; }
    [MultilingualName("حداقل سفارش", "الحد الأدنى للطلب")]
    public decimal MinOrderAmount { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
}
