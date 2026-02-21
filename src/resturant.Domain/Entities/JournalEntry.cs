using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("journal_entries")]
[MultilingualName("سند حسابداری", "قيد محاسبي")]
public class JournalEntry : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long EntryId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long? BranchId { get; set; }
    [MultilingualName("تاریخ سند", "تاريخ القيد")]
    public DateTime EntryDate { get; set; }
    [MultilingualName("توضیحات", "الوصف")]
    public string? Description { get; set; }
    [MultilingualName("نوع مرجع", "نوع المرجع")]
    public string? ReferenceType { get; set; }
    [MultilingualName("شناسه مرجع", "معرف المرجع")]
    public long? ReferenceId { get; set; }
    [MultilingualName("حساب بدهکار", "الحساب المدين")]
    public long DebitAccountId { get; set; }
    [MultilingualName("حساب بستانکار", "الحساب الدائن")]
    public long CreditAccountId { get; set; }
    [MultilingualName("مبلغ", "المبلغ")]
    public decimal Amount { get; set; }
    [MultilingualName("ایجاد کننده", "أنشئ بواسطة")]
    public long? CreatedBy { get; set; }
}
