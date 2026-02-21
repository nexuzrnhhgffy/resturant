using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("pos_devices")]
[MultilingualName("دستگاه پوز", "جهاز نقاط البيع")]
public class PosDevice : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long PosDeviceId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("نام دستگاه", "اسم الجهاز")]
    public string DeviceName { get; set; }
    [MultilingualName("شماره سریال", "الرقم التسلسلي")]
    public string SerialNumber { get; set; }
    [MultilingualName("مدل", "الطراز")]
    public string Model { get; set; }
    [MultilingualName("آدرس IP", "عنوان IP")]
    public string IpAddress { get; set; }
    [MultilingualName("شماره پذیرنده", "رقم التاجر")]
    public string MerchantId { get; set; }
    [MultilingualName("شماره ترمینال", "رقم المحطة")]
    public string TerminalId { get; set; }
    [MultilingualName("وضعیت", "الحالة")]
    public string Status { get; set; }
    [MultilingualName("آخرین اتصال", "آخر اتصال")]
    public DateTime? LastConnection { get; set; }
}
