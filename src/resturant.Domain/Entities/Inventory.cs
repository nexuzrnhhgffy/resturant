using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("inventory")]
[MultilingualName("انبار", "المخزون")]
public class Inventory : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long InventoryId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("نام آیتم", "اسم العنصر")]
    public string ItemName { get; set; }
    [MultilingualName("دسته", "الفئة")]
    public string Category { get; set; }
    [MultilingualName("واحد", "الوحدة")]
    public string Unit { get; set; }
    [MultilingualName("موجودی فعلی", "الكمية الحالية")]
    public decimal CurrentQuantity { get; set; }
    [MultilingualName("حداقل موجودی", "الحد الأدنى للكمية")]
    public decimal MinimumQuantity { get; set; }
    [MultilingualName("قیمت واحد", "تكلفة الوحدة")]
    public decimal UnitCost { get; set; }
    [MultilingualName("شناسه تامین کننده", "معرف المورد")]
    public long SupplierId { get; set; }
    [MultilingualName("آخر شارژ", "تاريخ إعادة التزويد")]
    public DateTime? LastRestockDate { get; set; }
    [MultilingualName("تاریخ انقضا", "تاريخ الانتهاء")]
    public DateTime? ExpiryDate { get; set; }
    [MultilingualName("مکان", "الموقع")]
    public string Location { get; set; }
}
