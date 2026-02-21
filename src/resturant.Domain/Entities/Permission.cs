using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("permissions")]
[MultilingualName("دسترسی ها", "الأذونات")]
public class Permission : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long PermissionId { get; set; }
    [MultilingualName("کد دسترسی", "رمز الإذن")]
    public string? PermissionCode { get; set; }
    [MultilingualName("توضیحات", "الوصف")]
    public string? Description { get; set; }
    [MultilingualName("دسته بندی", "الفئة")]
    public string? Category { get; set; }
}
