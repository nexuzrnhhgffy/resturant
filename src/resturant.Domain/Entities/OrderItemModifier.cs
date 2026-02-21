using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("order_item_modifiers")]
[MultilingualName("افزودنی آیتم سفارش", "معدل عنصر الطلب")]
public class OrderItemModifier : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public new long Id { get; set; }
    [MultilingualName("شناسه آیتم سفارش", "معرف عنصر الطلب")]
    public long OrderItemId { get; set; }
    [MultilingualName("شناسه افزودنی", "معرف المعدل")]
    public long ModifierId { get; set; }
    [MultilingualName("تعداد", "الكمية")]
    public int Quantity { get; set; }
    [MultilingualName("قیمت اضافی", "سعر إضافي")]
    public decimal AdditionalPrice { get; set; }
}
