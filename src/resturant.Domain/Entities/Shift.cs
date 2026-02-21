using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("shifts")]
[MultilingualName("شیفت", "الوردية")]
public class Shift : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long ShiftId { get; set; }
    [MultilingualName("شناسه کارمند", "معرف الموظف")]
    public long EmployeeId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("تاریخ شیفت", "تاريخ الوردية")]
    public DateTime ShiftDate { get; set; }
    [MultilingualName("شروع", "وقت البدء")]
    public TimeSpan StartTime { get; set; }
    [MultilingualName("پایان", "وقت النهاية")]
    public TimeSpan EndTime { get; set; }
    [MultilingualName("وضعیت", "الحالة")]
    public string? Status { get; set; }
}
