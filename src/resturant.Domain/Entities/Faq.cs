using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resturant.Domain.Common;
using resturant.Domain.Enums;

namespace resturant.Domain.Entities;

[Table("faqs")]
[MultilingualName("سوالات متداول", "الأسئلة الشائعة")]
public class Faq : BaseEntity
{
    [MultilingualName("شناسه", "المعرف")]
    public long FaqId { get; set; }
    [MultilingualName("سوال", "السؤال")]
    public string? Question { get; set; }
    [MultilingualName("پاسخ", "الجواب")]
    public string? Answer { get; set; }
    [MultilingualName("دسته", "الفئة")]
    public string? Category { get; set; }
    [MultilingualName("ترتیب", "الترتيب")]
    public int DisplayOrder { get; set; }
    [MultilingualName("فعال", "نشط")]
    public bool IsActive { get; set; }
}
