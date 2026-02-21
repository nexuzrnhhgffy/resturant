using Microsoft.EntityFrameworkCore;
using resturant.Domain.Entities;

namespace resturant.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Branch> Branchs { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<WalletTransaction> WalletTransactions { get; set; }
    public DbSet<MenuCategory> MenuCategorys { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<ModifierGroup> ModifierGroups { get; set; }
    public DbSet<Modifier> Modifiers { get; set; }
    public DbSet<MenuItemModifier> MenuItemModifiers { get; set; }
    public DbSet<Tablet> Tablets { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderItemModifier> OrderItemModifiers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresss { get; set; }
    public DbSet<DeliveryDetail> DeliveryDetails { get; set; }
    public DbSet<DiscountCode> DiscountCodes { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<UserRanking> UserRankings { get; set; }
    public DbSet<Inventory> Inventorys { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<InventoryLog> InventoryLogs { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<AdClient> AdClients { get; set; }
    public DbSet<Ad> Ads { get; set; }
    public DbSet<Screen> Screens { get; set; }
    public DbSet<AdCampaign> AdCampaigns { get; set; }
    public DbSet<AdPlayLog> AdPlayLogs { get; set; }
    public DbSet<SiteSetting> SiteSettings { get; set; }
    public DbSet<SitePage> SitePages { get; set; }
    public DbSet<WebBanner> WebBanners { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<UserActivityLog> UserActivityLogs { get; set; }
    public DbSet<VerificationToken> VerificationTokens { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Camera> Cameras { get; set; }
    public DbSet<PosDevice> PosDevices { get; set; }
    public DbSet<PosTransaction> PosTransactions { get; set; }
    public DbSet<CashRegister> CashRegisters { get; set; }
    public DbSet<CashRegisterLog> CashRegisterLogs { get; set; }
    public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
    public DbSet<JournalEntry> JournalEntrys { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategorys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Global Soft Delete Filters
        modelBuilder.Entity<Branch>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<AppUser>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Wallet>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<WalletTransaction>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<MenuCategory>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<MenuItem>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<ModifierGroup>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Modifier>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<MenuItemModifier>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Tablet>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Table>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Reservation>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Order>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<OrderItem>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<OrderItemModifier>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<CustomerAddress>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<DeliveryDetail>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<DiscountCode>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Payment>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Employee>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Shift>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<UserRanking>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Inventory>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Supplier>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Recipe>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<InventoryLog>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Review>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<AdClient>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Ad>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Screen>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<AdCampaign>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<AdPlayLog>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<SiteSetting>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<SitePage>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<WebBanner>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Faq>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<BlogPost>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<RefreshToken>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<UserActivityLog>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<VerificationToken>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Role>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Permission>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<RolePermission>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<UserRole>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Camera>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<PosDevice>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<PosTransaction>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<CashRegister>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<CashRegisterLog>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<ChartOfAccount>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<JournalEntry>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Expense>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<ExpenseCategory>().HasQueryFilter(b => !b.IsDeleted);

        
        // Configure Relationships
        ConfigureDecimalPrecision(modelBuilder);
        ConfigureRelationships(modelBuilder);
    }
    
        private void ConfigureDecimalPrecision(ModelBuilder modelBuilder)
    {
        // Money fields
        modelBuilder.Entity<AdCampaign>().Property(x => x.TotalCost).HasPrecision(18, 2);
        modelBuilder.Entity<AppUser>().Property(x => x.TotalSpent).HasPrecision(18, 2);
        modelBuilder.Entity<CashRegister>().Property(x => x.CurrentBalance).HasPrecision(18, 2);
        modelBuilder.Entity<CashRegisterLog>().Property(x => x.Amount).HasPrecision(18, 2);
        modelBuilder.Entity<ChartOfAccount>().Property(x => x.Balance).HasPrecision(18, 2);
        modelBuilder.Entity<DeliveryDetail>().Property(x => x.DeliveryFee).HasPrecision(18, 2);
        modelBuilder.Entity<DiscountCode>().Property(x => x.MinOrderAmount).HasPrecision(18, 2);
        modelBuilder.Entity<DiscountCode>().Property(x => x.Value).HasPrecision(18, 2);
        modelBuilder.Entity<Employee>().Property(x => x.Salary).HasPrecision(18, 2);
        modelBuilder.Entity<Expense>().Property(x => x.Amount).HasPrecision(18, 2);
        modelBuilder.Entity<Inventory>().Property(x => x.UnitCost).HasPrecision(18, 2);
        modelBuilder.Entity<InventoryLog>().Property(x => x.CurrentStock).HasPrecision(18, 4);
        modelBuilder.Entity<JournalEntry>().Property(x => x.Amount).HasPrecision(18, 2);
        modelBuilder.Entity<MenuItem>().Property(x => x.Cost).HasPrecision(18, 2);
        modelBuilder.Entity<MenuItem>().Property(x => x.Price).HasPrecision(18, 2);
        modelBuilder.Entity<Modifier>().Property(x => x.ExtraPrice).HasPrecision(18, 2);
        modelBuilder.Entity<Order>().Property(x => x.DiscountAmount).HasPrecision(18, 2);
        modelBuilder.Entity<Order>().Property(x => x.FinalAmount).HasPrecision(18, 2);
        modelBuilder.Entity<Order>().Property(x => x.ServiceCharge).HasPrecision(18, 2);
        modelBuilder.Entity<Order>().Property(x => x.TaxAmount).HasPrecision(18, 2);
        modelBuilder.Entity<Order>().Property(x => x.TotalAmount).HasPrecision(18, 2);
        modelBuilder.Entity<OrderItem>().Property(x => x.Subtotal).HasPrecision(18, 2);
        modelBuilder.Entity<OrderItem>().Property(x => x.UnitPrice).HasPrecision(18, 2);
        modelBuilder.Entity<OrderItemModifier>().Property(x => x.AdditionalPrice).HasPrecision(18, 2);
        modelBuilder.Entity<Payment>().Property(x => x.Amount).HasPrecision(18, 2);
        modelBuilder.Entity<Payment>().Property(x => x.TipAmount).HasPrecision(18, 2);
        modelBuilder.Entity<PosTransaction>().Property(x => x.Amount).HasPrecision(18, 2);
        modelBuilder.Entity<UserRanking>().Property(x => x.AverageSpent).HasPrecision(18, 2);
        modelBuilder.Entity<Wallet>().Property(x => x.Balance).HasPrecision(18, 2);
        modelBuilder.Entity<Wallet>().Property(x => x.TotalDeposited).HasPrecision(18, 2);
        modelBuilder.Entity<Wallet>().Property(x => x.TotalWithdrawn).HasPrecision(18, 2);
        modelBuilder.Entity<WalletTransaction>().Property(x => x.Amount).HasPrecision(18, 2);
        modelBuilder.Entity<WalletTransaction>().Property(x => x.BalanceAfter).HasPrecision(18, 2);
        modelBuilder.Entity<Inventory>().Property(x => x.CurrentQuantity).HasPrecision(18, 4);
        modelBuilder.Entity<Inventory>().Property(x => x.MinimumQuantity).HasPrecision(18, 4);
        modelBuilder.Entity<InventoryLog>().Property(x => x.QuantityChange).HasPrecision(18, 4);
        modelBuilder.Entity<Recipe>().Property(x => x.Quantity).HasPrecision(18, 4);
        modelBuilder.Entity<CustomerAddress>().Property(x => x.Latitude).HasPrecision(18, 6);
        modelBuilder.Entity<CustomerAddress>().Property(x => x.Longitude).HasPrecision(18, 6);
        modelBuilder.Entity<DeliveryDetail>().Property(x => x.DistanceKm).HasPrecision(18, 6);
    }

    private void ConfigureRelationships(ModelBuilder modelBuilder)
    {
        // Order -> AppUser
        modelBuilder.Entity<Order>()
            .HasOne<AppUser>()
            .WithMany()
            .HasForeignKey(o => o.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Order -> Branch
        modelBuilder.Entity<Order>()
            .HasOne<Branch>()
            .WithMany()
            .HasForeignKey(o => o.BranchId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // OrderItem -> Order
        modelBuilder.Entity<OrderItem>()
            .HasOne<Order>()
            .WithMany()
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // MenuItem -> MenuCategory
        modelBuilder.Entity<MenuItem>()
            .HasOne<MenuCategory>()
            .WithMany()
            .HasForeignKey(m => m.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Reservation -> AppUser
        modelBuilder.Entity<Reservation>()
            .HasOne<AppUser>()
            .WithMany()
            .HasForeignKey(r => r.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Reservation -> Table
        modelBuilder.Entity<Reservation>()
            .HasOne<Table>()
            .WithMany()
            .HasForeignKey(r => r.TableId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Payment -> Order
        modelBuilder.Entity<Payment>()
            .HasOne<Order>()
            .WithMany()
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Employee -> AppUser
        modelBuilder.Entity<Employee>()
            .HasOne<AppUser>()
            .WithMany()
            .HasForeignKey(e => e.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Employee -> Branch
        modelBuilder.Entity<Employee>()
            .HasOne<Branch>()
            .WithMany()
            .HasForeignKey(e => e.BranchId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        // Seed Roles
        if (!context.Roles.Any())
        {
            context.Roles.AddRange(
                new Role { RoleName = "Admin", Description = "System Administrator", IsActive = true },
                new Role { RoleName = "Manager", Description = "Branch Manager", IsActive = true },
                new Role { RoleName = "Waiter", Description = "Serving Staff", IsActive = true },
                new Role { RoleName = "Chef", Description = "Kitchen Staff", IsActive = true },
                new Role { RoleName = "Customer", Description = "Restaurant Customer", IsActive = true },
                new Role { RoleName = "DeliveryDriver", Description = "Delivery Driver", IsActive = true }
            );
        }
        
        // Seed Permissions
        if (!context.Permissions.Any())
        {
            context.Permissions.AddRange(
                new Permission { PermissionCode = "orders.view", Description = "View Orders", Category = "Orders" },
                new Permission { PermissionCode = "orders.create", Description = "Create Orders", Category = "Orders" },
                new Permission { PermissionCode = "orders.edit", Description = "Edit Orders", Category = "Orders" },
                new Permission { PermissionCode = "orders.delete", Description = "Delete Orders", Category = "Orders" },
                new Permission { PermissionCode = "menu.view", Description = "View Menu", Category = "Menu" },
                new Permission { PermissionCode = "menu.create", Description = "Create Menu Items", Category = "Menu" },
                new Permission { PermissionCode = "menu.edit", Description = "Edit Menu Items", Category = "Menu" },
                new Permission { PermissionCode = "menu.delete", Description = "Delete Menu Items", Category = "Menu" },
                new Permission { PermissionCode = "users.view", Description = "View Users", Category = "Users" },
                new Permission { PermissionCode = "users.manage", Description = "Manage Users", Category = "Users" },
                new Permission { PermissionCode = "reports.view", Description = "View Reports", Category = "Reports" },
                new Permission { PermissionCode = "settings.manage", Description = "Manage Settings", Category = "Settings" },
                new Permission { PermissionCode = "inventory.view", Description = "View Inventory", Category = "Inventory" },
                new Permission { PermissionCode = "inventory.manage", Description = "Manage Inventory", Category = "Inventory" }
            );
        }
        
        context.SaveChanges();
    }
}


