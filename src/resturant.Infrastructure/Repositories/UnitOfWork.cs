using resturant.Domain.Entities;
using resturant.Domain.Interfaces;
using resturant.Infrastructure.Data;
using resturant.Infrastructure.Repositories;

namespace resturant.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IRepository<Branch>? _branches;
    private IRepository<AppUser>? _appUsers;
    private IRepository<Order>? _orders;
    private IRepository<OrderItem>? _orderItems;
    private IRepository<MenuItem>? _menuItems;
    private IRepository<MenuCategory>? _menuCategories;
    private IRepository<Table>? _tables;
    private IRepository<Reservation>? _reservations;
    private IRepository<Payment>? _payments;
    private IRepository<Employee>? _employees;
    private IRepository<Inventory>? _inventory;
    private IRepository<Role>? _roles;
    private IRepository<Permission>? _permissions;
    private IRepository<UserRole>? _userRoles;
    private IRepository<RolePermission>? _rolePermissions;
    private IRepository<DiscountCode>? _discountCodes;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepository<Branch> Branches => _branches ??= new Repository<Branch>(_context);
    public IRepository<AppUser> AppUsers => _appUsers ??= new Repository<AppUser>(_context);
    public IRepository<Order> Orders => _orders ??= new Repository<Order>(_context);
    public IRepository<OrderItem> OrderItems => _orderItems ??= new Repository<OrderItem>(_context);
    public IRepository<MenuItem> MenuItems => _menuItems ??= new Repository<MenuItem>(_context);
    public IRepository<MenuCategory> MenuCategories => _menuCategories ??= new Repository<MenuCategory>(_context);
    public IRepository<Table> Tables => _tables ??= new Repository<Table>(_context);
    public IRepository<Reservation> Reservations => _reservations ??= new Repository<Reservation>(_context);
    public IRepository<Payment> Payments => _payments ??= new Repository<Payment>(_context);
    public IRepository<Employee> Employees => _employees ??= new Repository<Employee>(_context);
    public IRepository<Inventory> Inventory => _inventory ??= new Repository<Inventory>(_context);
    public IRepository<Role> Roles => _roles ??= new Repository<Role>(_context);
    public IRepository<Permission> Permissions => _permissions ??= new Repository<Permission>(_context);
    public IRepository<UserRole> UserRoles => _userRoles ??= new Repository<UserRole>(_context);
    public IRepository<RolePermission> RolePermissions => _rolePermissions ??= new Repository<RolePermission>(_context);
    public IRepository<DiscountCode> DiscountCodes => _discountCodes ??= new Repository<DiscountCode>(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
