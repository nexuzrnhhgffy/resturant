using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("roles")]
[MultilingualName("نقش ها", "الأدوار")]
public class Role : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long RoleId { get; set; }
    [MultilingualName("نام نقش", "اسم الدور")]
    public string? RoleName { get; set; }
    [MultilingualName("توضیحات", "الوصف")]
    public string? Description { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
}
