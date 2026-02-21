using System.ComponentModel.DataAnnotations;
using resturant.Domain.Common;

namespace resturant.Domain.Entities;

[MultilingualName("کلاس پایه", "فئة أساسية")]
public abstract class BaseEntity
{
    [Key]
    public long Id { get; set; }
    
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
