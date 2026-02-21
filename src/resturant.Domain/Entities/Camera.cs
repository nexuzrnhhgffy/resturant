using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("cameras")]
[MultilingualName("دوربین", "كاميرا")]
public class Camera : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long CameraId { get; set; }
    [MultilingualName("شناسه شعبه", "معرف الفرع")]
    public long BranchId { get; set; }
    [MultilingualName("نام دوربین", "اسم الكاميرا")]
    public string? CameraName { get; set; }
    [MultilingualName("موقعیت نصب", "موقع التركيب")]
    public string? LocationDescription { get; set; }
    [MultilingualName("آدرس IP", "عنوان IP")]
    public string? IpAddress { get; set; }
    [MultilingualName("آدرس استریم", "رابط البث")]
    public string? StreamUrl { get; set; }
    [MultilingualName("نام کاربری", "اسم المستخدم")]
    public string? Username { get; set; }
    [MultilingualName("رمز عبور", "كلمة المرور")]
    public string? Password { get; set; }
    [MultilingualName("وضعیت", "الحالة")]
    public string? Status { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
}
