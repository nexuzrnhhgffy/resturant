using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("menu_item_modifiers")]
[MultilingualName("آیتم افزودنی منو", "عنصر القائمة معدل")]
public class MenuItemModifier : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long Id { get; set; }
    [MultilingualName("شناسه آیتم", "معرف العنصر")]
    public long MenuItemId { get; set; }
    [MultilingualName("شناسه گروه", "معرف المجموعة")]
    public long ModifierGroupId { get; set; }
}
