using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("site_pages")]
[MultilingualName("صفحات سایت", "صفحات الموقع")]
public class SitePage : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long PageId { get; set; }
    [MultilingualName("عنوان", "العنوان")]
    public string Title { get; set; }
    [MultilingualName("اسلاگ", "الرابط")]
    public string Slug { get; set; }
    [MultilingualName("محتوا", "المحتوى")]
    public string Content { get; set; }
    [MultilingualName("عنوان متا", "عنوان ميتا")]
    public string MetaTitle { get; set; }
    [MultilingualName("توضیحات متا", "وصف ميتا")]
    public string MetaDescription { get; set; }
    [MultilingualName("منتشر شده", "منشور")]
    public bool IsPublished { get; set; }
}
