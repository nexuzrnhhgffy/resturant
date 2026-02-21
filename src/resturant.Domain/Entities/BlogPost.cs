using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("blog_posts")]
[MultilingualName("پست های بلاگ", "مشاركات المدونة")]
public class BlogPost : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long PostId { get; set; }
    [MultilingualName("عنوان", "العنوان")]
    public string? Title { get; set; }
    [MultilingualName("اسلاگ", "الرابط")]
    public string? Slug { get; set; }
    [MultilingualName("خلاصه", "ملخص")]
    public string? Summary { get; set; }
    [MultilingualName("محتوا", "المحتوى")]
    public string? Content { get; set; }
    [MultilingualName("تصویر کاور", "صورة الغلاف")]
    public string? CoverImage { get; set; }
    [MultilingualName("شناسه نویسنده", "معرف المؤلف")]
    public long AuthorId { get; set; }
    [MultilingualName("تعداد بازدید", "عدد المشاهدات")]
    public int ViewCount { get; set; }
    [MultilingualName("منتشر شده", "منشور")]
    public bool IsPublished { get; set; }
    [MultilingualName("زمان انتشار", "وقت النشر")]
    public DateTime PublishedAt { get; set; }
}
