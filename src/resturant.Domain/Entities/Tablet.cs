using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("tablets")]
[MultilingualName("تبلت", "تابلت")]
public class Tablet : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long TabletId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("نام تبلت", "اسم التابلت")]
    public string TabletName { get; set; }
    [MultilingualName("شماره سریال", "الرقم التسلسلي")]
    public string SerialNumber { get; set; }
    [MultilingualName("وضعیت", "الحالة")]
    public string Status { get; set; }
    [MultilingualName("آخرین حضور", "آخر ظهور")]
    public DateTime? LastSeen { get; set; }
    [MultilingualName("میزان شارژ", "مستوى البطارية")]
    public int? BatteryLevel { get; set; }
}
