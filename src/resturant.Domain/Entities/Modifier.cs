using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("modifiers")]
[MultilingualName("افزودنی", "معدل")]
public class Modifier : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long ModifierId { get; set; }
    [MultilingualName("شناسه گروه", "معرف المجموعة")]
    public long ModifierGroupId { get; set; }
    [MultilingualName("نام", "الاسم")]
    public string Name { get; set; }
    [MultilingualName("قیمت اضافه", "سعر إضافي")]
    public decimal ExtraPrice { get; set; }
    [MultilingualName("موجود", "متاح")]
    public bool IsAvailable { get; set; }
}
