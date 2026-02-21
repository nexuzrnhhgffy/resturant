using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("inventory_logs")]
[MultilingualName("لاگ انبار", "سجل المخزون")]
public class InventoryLog : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long LogId { get; set; }
    [MultilingualName("شناسه آیتم انبار", "معرف عنصر المخزون")]
    public long InventoryId { get; set; }
    [MultilingualName("تغییر تعداد", "تغير الكمية")]
    public decimal QuantityChange { get; set; }
    [MultilingualName("موجودی فعلی", "المخزون الحالي")]
    public decimal CurrentStock { get; set; }
    [MultilingualName("دلیل", "السبب")]
    public string Reason { get; set; }
    [MultilingualName("ارجاع", "المرجع")]
    public long? ReferenceId { get; set; }
    [MultilingualName("انجام دهنده", "أجراه")]
    public long? PerformedBy { get; set; }
}
