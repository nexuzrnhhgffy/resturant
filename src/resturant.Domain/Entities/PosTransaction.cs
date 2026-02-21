using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("pos_transactions")]
[MultilingualName("تراکنش پوز", "معاملة نقاط البيع")]
public class PosTransaction : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long PosTransactionId { get; set; }
    [MultilingualName("شناسه دستگاه", "معرف الجهاز")]
    public long PosDeviceId { get; set; }
    [MultilingualName("شناسه پرداخت", "معرف الدفع")]
    public long? PaymentId { get; set; }
    [MultilingualName("مبلغ", "المبلغ")]
    public decimal Amount { get; set; }
    [MultilingualName("شماره کارت ماسکه", "رقم البطاقة المقنع")]
    public string CardNumberMasked { get; set; }
    [MultilingualName("شماره پیگیری", "رقم التتبع")]
    public string TraceNumber { get; set; }
    [MultilingualName("شماره مرجع", "رقم المرجع")]
    public string ReferenceNumber { get; set; }
    [MultilingualName("تاریخ تراکنش", "تاريخ المعاملة")]
    public DateTime TransactionDate { get; set; }
    [MultilingualName("کد پاسخ", "رمز الاستجابة")]
    public string ResponseCode { get; set; }
    [MultilingualName("وضعیت", "الحالة")]
    public string Status { get; set; }
}
