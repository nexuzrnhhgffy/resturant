using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("modifier_groups")]
[MultilingualName("گروه افزودنی", "مجموعة المعدلات")]
public class ModifierGroup : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long ModifierGroupId { get; set; }
    [MultilingualName("نام", "الاسم")]
    public string? Name { get; set; }
    [MultilingualName("حداقل انتخاب", "الحد الأدنى للاختيار")]
    public int MinSelect { get; set; }
    [MultilingualName("حداکثر انتخاب", "الحد الأقصى للاختيار")]
    public int MaxSelect { get; set; }
    [MultilingualName("نوع نمایش", "نوع العرض")]
    public string? DisplayType { get; set; }
}
