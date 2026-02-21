using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("suppliers")]
[MultilingualName("تامین کننده", "المورد")]
public class Supplier : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long SupplierId { get; set; }
    [MultilingualName("نام تامین کننده", "اسم المورد")]
    public string SupplierName { get; set; }
    [MultilingualName("شخص تماس", "شخص الاتصال")]
    public string ContactPerson { get; set; }
    [MultilingualName("تلفن", "رقم الهاتف")]
    public string Phone { get; set; }
    [MultilingualName("ایمیل", "البريد الإلكتروني")]
    public string Email { get; set; }
    [MultilingualName("آدرس", "العنوان")]
    public string Address { get; set; }
    [MultilingualName("کالاهای تامین شده", "العناصر الموردة")]
    public string SupplyItems { get; set; }
    [MultilingualName("شرایط پرداخت", "شروط الدفع")]
    public string PaymentTerms { get; set; }
    [MultilingualName("امتیاز", "التقييم")]
    public int Rating { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
}
