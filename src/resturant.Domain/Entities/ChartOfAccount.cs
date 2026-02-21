using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("chart_of_accounts")]
[MultilingualName("سرفصل حساب", "دليل الحسابات")]
public class ChartOfAccount : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long AccountId { get; set; }
    [MultilingualName("کد حساب", "رمز الحساب")]
    public string AccountCode { get; set; }
    [MultilingualName("نام حساب", "اسم الحساب")]
    public string AccountName { get; set; }
    [MultilingualName("حساب والد", "الحساب الرئيسي")]
    public long? ParentAccountId { get; set; }
    [MultilingualName("نوع حساب", "نوع الحساب")]
    public string AccountType { get; set; }
    [MultilingualName("مانده", "الرصيد")]
    public decimal Balance { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
}
