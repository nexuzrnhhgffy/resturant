using resturant.Domain.Entities;

namespace resturant.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Branch> Branches { get; }
    IRepository<AppUser> AppUsers { get; }
    IRepository<Order> Orders { get; }
    IRepository<OrderItem> OrderItems { get; }
    IRepository<MenuItem> MenuItems { get; }
    IRepository<MenuCategory> MenuCategories { get; }
    IRepository<Table> Tables { get; }
    IRepository<Reservation> Reservations { get; }
    IRepository<Payment> Payments { get; }
    IRepository<Employee> Employees { get; }
    IRepository<Inventory> Inventory { get; }
    IRepository<Role> Roles { get; }
    IRepository<Permission> Permissions { get; }
    IRepository<UserRole> UserRoles { get; }
    IRepository<RolePermission> RolePermissions { get; }
    IRepository<DiscountCode> DiscountCodes { get; }
    Task<int> SaveChangesAsync();
}
