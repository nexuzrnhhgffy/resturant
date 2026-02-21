using System;
using System.ComponentModel.DataAnnotations;

namespace resturant.Domain.DTOs;

/// <summary>
/// DTO برای مدیریت کاربران
/// </summary>
public class UserManagementDto
{
    [Display(Name = "شناسه")]
    public long AppUserId { get; set; }

    [Display(Name = "نام")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "نام خانوادگی")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "نام کامل")]
    public string FullName => $"{FirstName} {LastName}";

    [Display(Name = "تلفن")]
    public string? Phone { get; set; }

    [Display(Name = "ایمیل")]
    [EmailAddress]
    public string? Email { get; set; }

    [Display(Name = "نوع مشتری")]
    public string CustomerType { get; set; } = string.Empty;

    [Display(Name = "نقش‌ها")]
    public string Roles { get; set; } = string.Empty;

    [Display(Name = "امتیاز وفاداری")]
    public int LoyaltyPoints { get; set; }

    [Display(Name = "کل خرید")]
    public decimal TotalSpent { get; set; }

    [Display(Name = "تعداد بازدید")]
    public int VisitCount { get; set; }

    [Display(Name = "آخرین بازدید")]
    public DateTime? LastVisit { get; set; }

    [Display(Name = "تاریخ ثبت نام")]
    public DateTime RegistrationDate { get; set; }

    [Display(Name = "فعال")]
    public bool IsActive { get; set; }

    [Display(Name = "یادداشت")]
    public string Notes { get; set; } = string.Empty;
}

/// <summary>
/// DTO برای جزئیات کاربر
/// </summary>
public class UserDetailDto
{
    [Display(Name = "شناسه")]
    public long AppUserId { get; set; }

    [Display(Name = "نام")]
    [Required(ErrorMessage = "نام الزامی است")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "نام خانوادگی الزامی است")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "تلفن")]
    [Phone(ErrorMessage = "شماره تلفن نامعتبر است")]
    public string? Phone { get; set; }

    [Display(Name = "ایمیل")]
    [EmailAddress(ErrorMessage = "ایمیل نامعتبر است")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "نوع مشتری")]
    public string CustomerType { get; set; } = string.Empty;

    [Display(Name = "امتیاز وفاداری")]
    public int LoyaltyPoints { get; set; }

    [Display(Name = "کل خرید")]
    public decimal TotalSpent { get; set; }

    [Display(Name = "تعداد بازدید")]
    public int VisitCount { get; set; }

    [Display(Name = "آخرین بازدید")]
    public DateTime? LastVisit { get; set; }

    [Display(Name = "تاریخ تولد")]
    public DateTime? BirthDate { get; set; }

    [Display(Name = "تاریخ ثبت نام")]
    public DateTime RegistrationDate { get; set; }

    [Display(Name = "فعال")]
    public bool IsActive { get; set; }

    [Display(Name = "یادداشت")]
    [MaxLength(1000)]
    public string Notes { get; set; } = string.Empty;

    [Display(Name = "نقش‌ها")]
    public List<long> RoleIds { get; set; } = new();

    [Display(Name = "نقش‌های نمایشی")]
    public List<string> RoleNames { get; set; } = new();
}

/// <summary>
/// DTO برای نقش‌ها
/// </summary>
public class RoleDto
{
    [Display(Name = "شناسه")]
    public long RoleId { get; set; }

    [Display(Name = "نام نقش")]
    [Required(ErrorMessage = "نام نقش الزامی است")]
    [MaxLength(100)]
    public string RoleName { get; set; } = string.Empty;

    [Display(Name = "توضیحات")]
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "فعال")]
    public bool IsActive { get; set; }

    [Display(Name = "تعداد دسترسی‌ها")]
    public int PermissionCount { get; set; }

    [Display(Name = "تعداد کاربران")]
    public int UserCount { get; set; }

    [Display(Name = "دسترسی‌ها")]
    public List<long> PermissionIds { get; set; } = new();
}

/// <summary>
/// DTO برای دسترسی‌ها
/// </summary>
public class PermissionDto
{
    [Display(Name = "شناسه")]
    public long PermissionId { get; set; }

    [Display(Name = "کد دسترسی")]
    [Required(ErrorMessage = "کد دسترسی الزامی است")]
    [MaxLength(100)]
    public string PermissionCode { get; set; } = string.Empty;

    [Display(Name = "توضیحات")]
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "دسته‌بندی")]
    [MaxLength(100)]
    public string Category { get; set; } = string.Empty;

    [Display(Name = "نمایش عنوان")]
    public string DisplayName => !string.IsNullOrEmpty(Category) ? $"{Category} - {PermissionCode}" : PermissionCode;
}

/// <summary>
/// DTO برای دسترسی‌های نقش
/// </summary>
public class RolePermissionDto
{
    [Display(Name = "شناسه نقش")]
    public long RoleId { get; set; }

    [Display(Name = "نام نقش")]
    public string RoleName { get; set; } = string.Empty;

    [Display(Name = "دسترسی‌ها")]
    public List<PermissionDto> Permissions { get; set; } = new();

    [Display(Name = "تعداد دسترسی‌ها")]
    public int PermissionCount => Permissions.Count;
}

/// <summary>
/// DTO برای نقش‌های کاربر
/// </summary>
public class UserRoleDto
{
    [Display(Name = "شناسه کاربر")]
    public long UserId { get; set; }

    [Display(Name = "نام کاربر")]
    public string UserName { get; set; } = string.Empty;

    [Display(Name = "نقش‌های فعلی")]
    public List<string> CurrentRoles { get; set; } = new();

    [Display(Name = "نقش‌های برای اختصاص")]
    public List<RoleDto> AvailableRoles { get; set; } = new();

    [Display(Name = "شناسه‌های نقش برای اختصاص")]
    public List<long> RoleIdsToAssign { get; set; } = new();
}

/// <summary>
/// DTO برای خلاصه مدیریت
/// </summary>
public class ManagementSummaryDto
{
    [Display(Name = "تعداد کاربران")]
    public int TotalUsers { get; set; }

    [Display(Name = "کاربران فعال")]
    public int ActiveUsers { get; set; }

    [Display(Name = "کاربران غیرفعال")]
    public int InactiveUsers { get; set; }

    [Display(Name = "تعداد نقش‌ها")]
    public int TotalRoles { get; set; }

    [Display(Name = "تعداد دسترسی‌ها")]
    public int TotalPermissions { get; set; }

    [Display(Name = "نقش‌های فعال")]
    public int ActiveRoles { get; set; }

    [Display(Name = "کاربران امروز")]
    public int UsersToday { get; set; }

    [Display(Name = "کل خریدها")]
    public decimal TotalPurchases { get; set; }
}
