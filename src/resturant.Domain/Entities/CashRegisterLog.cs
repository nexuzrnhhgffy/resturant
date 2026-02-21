using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("cash_register_logs")]
[MultilingualName("حرکات صندوق", "سجل حركات الخزينة")]
public class CashRegisterLog : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long LogId { get; set; }
    [MultilingualName("شناسه صندوق", "معرف الخزينة")]
    public long CashRegisterId { get; set; }
    [MultilingualName("شناسه کارمند", "معرف الموظف")]
    public long EmployeeId { get; set; }
    [MultilingualName("مبلغ", "المبلغ")]
    public decimal Amount { get; set; }
    [MultilingualName("نوع حرکت", "نوع الحركة")]
    public string TransactionType { get; set; }
    [MultilingualName("توضیحات", "ملاحظات")]
    public string Notes { get; set; }
    [MultilingualName("تاریخ", "التاريخ")]
    public DateTime LogDate { get; set; }
}
