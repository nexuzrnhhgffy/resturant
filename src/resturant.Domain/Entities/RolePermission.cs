using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("role_permissions")]
[MultilingualName("دسترسی نقش", "إذن الدور")]
public class RolePermission : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long Id { get; set; }
    [MultilingualName("شناسه نقش", "معرف الدور")]
    public long RoleId { get; set; }
    [MultilingualName("شناسه دسترسی", "معرف الإذن")]
    public long PermissionId { get; set; }
}
