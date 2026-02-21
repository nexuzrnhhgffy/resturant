using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("cash_registers")]
[MultilingualName("صندوق", "الخزينة")]
public class CashRegister : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long CashRegisterId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("نام صندوق", "اسم الخزينة")]
    public string? RegisterName { get; set; }
    [MultilingualName("موجودی فعلی", "الرصيد الحالي")]
    public decimal CurrentBalance { get; set; }
    [MultilingualName("وضعیت", "الحالة")]
    public string? Status { get; set; }
    [MultilingualName("مسئول صندوق", "الموظف المسؤول")]
    public long? AssignedToEmployeeId { get; set; }
    [MultilingualName("آخرین بازگشایی", "آخر فتح")]
    public DateTime? LastOpenedAt { get; set; }
}
