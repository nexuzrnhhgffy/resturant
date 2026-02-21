using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("wallets")]
[MultilingualName("کیف پول", "محفظة")]
public class Wallet : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long WalletId { get; set; }
    [MultilingualName("شناسه کاربر", "معرف المستخدم")]
    public long AppUserId { get; set; }
    [MultilingualName("موجودی", "الرصيد")]
    public decimal Balance { get; set; }
    [MultilingualName("کل واریز", "إجمالي الودائع")]
    public decimal TotalDeposited { get; set; }
    [MultilingualName("کل برداشت", "إجمالي المسحوبات")]
    public decimal TotalWithdrawn { get; set; }
    [MultilingualName("تاریخ آخر تراکنش", "تاريخ آخر معاملة")]
    public DateTime? LastTransactionDate { get; set; }
}
