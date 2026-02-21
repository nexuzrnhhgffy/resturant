using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("order_items")]
[MultilingualName("آیتم سفارش", "عنصر الطلب")]
public class OrderItem : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long OrderItemId { get; set; }
    [MultilingualName("شناسه سفارش", "معرف الطلب")]
    public long OrderId { get; set; }
    [MultilingualName("شناسه آیتم منو", "معرف عنصر القائمة")]
    public long MenuItemId { get; set; }
    [MultilingualName("تعداد", "الكمية")]
    public int Quantity { get; set; }
    [MultilingualName("قیمت واحد", "سعر الوحدة")]
    public decimal UnitPrice { get; set; }
    [MultilingualName("جمع فرعی", "المجموع الفرعي")]
    public decimal Subtotal { get; set; }
    [MultilingualName("دستور پخت خاص", "تعليمات خاصة")]
    public string? SpecialInstructions { get; set; }
    [MultilingualName("وضعیت آیتم", "حالة العنصر")]
    public string? ItemStatus { get; set; }
    [MultilingualName("شروع آماده سازی", "بداية التحضير")]
    public DateTime? PreparationStartTime { get; set; }
    [MultilingualName("پایان آماده سازی", "نهاية التحضير")]
    public DateTime? PreparationEndTime { get; set; }
    [MultilingualName("آماده کننده", "أعد بواسطة")]
    public long? PreparedBy { get; set; }
    [MultilingualName("سرو کننده", "قدم بواسطة")]
    public long? ServedBy { get; set; }
}
