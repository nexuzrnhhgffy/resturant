using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("expenses")]
[MultilingualName("هزینه", "مصروف")]
public class Expense : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long ExpenseId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("دسته هزینه", "فئة المصروف")]
    public long ExpenseCategoryId { get; set; }
    [MultilingualName("مبلغ", "المبلغ")]
    public decimal Amount { get; set; }
    [MultilingualName("روش پرداخت", "طريقة الدفع")]
    public string PaymentMethod { get; set; }
    [MultilingualName("توضیحات", "الوصف")]
    public string Description { get; set; }
    [MultilingualName("تاریخ هزینه", "تاريخ المصروف")]
    public DateTime ExpenseDate { get; set; }
    [MultilingualName("پرداخت کننده", "المدفوع بواسطة")]
    public long? PaidBy { get; set; }
}
