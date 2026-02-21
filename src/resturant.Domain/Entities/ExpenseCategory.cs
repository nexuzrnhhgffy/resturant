using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("expense_categories")]
[MultilingualName("دسته بندی هزینه", "فئة المصروفات")]
public class ExpenseCategory : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long ExpenseCategoryId { get; set; }
    [MultilingualName("نام دسته", "اسم الفئة")]
    public string? CategoryName { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
}
