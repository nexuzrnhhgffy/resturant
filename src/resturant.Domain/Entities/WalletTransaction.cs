using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("wallet_transactions")]
[MultilingualName("تراکنش کیف پول", "معاملة المحفظة")]
public class WalletTransaction : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long TransactionId { get; set; }
    [MultilingualName("شناسه کیف پول", "معرف المحفظة")]
    public long WalletId { get; set; }
    [MultilingualName("مبلغ", "المبلغ")]
    public decimal Amount { get; set; }
    [MultilingualName("نوع تراکنش", "نوع المعاملة")]
    public string TransactionType { get; set; }
    [MultilingualName("شناسه ارجاع", "رقم المرجع")]
    public long? ReferenceId { get; set; }
    [MultilingualName("توضیحات", "الوصف")]
    public string Description { get; set; }
    [MultilingualName("موجودی بعد", "الرصيد بعد")]
    public decimal BalanceAfter { get; set; }
}
