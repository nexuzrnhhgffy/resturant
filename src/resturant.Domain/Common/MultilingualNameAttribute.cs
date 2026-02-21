using System;

namespace resturant.Domain.Common;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
public class MultilingualNameAttribute : Attribute
{
    public string PersianName { get; set; }
    public string ArabicName { get; set; }

    public MultilingualNameAttribute(string persian, string arabic)
    {
        PersianName = persian;
        ArabicName = arabic;
    }
}
