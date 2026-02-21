using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("tables")]
[MultilingualName("میز", "الطاولة")]
public class Table : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long TableId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("شماره میز", "رقم الطاولة")]
    public string TableNumber { get; set; }
    [MultilingualName("نام میز", "اسم الطاولة")]
    public string TableName { get; set; }
    [MultilingualName("ظرفیت", "السعة")]
    public int Capacity { get; set; }
    [MultilingualName("نوع میز", "نوع الطاولة")]
    public string TableType { get; set; }
    [MultilingualName("موقعیت", "الموقع")]
    public string LocationDescription { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
    [MultilingualName("وضعیت فعلی", "الحالة الحالية")]
    public string CurrentStatus { get; set; }
}
