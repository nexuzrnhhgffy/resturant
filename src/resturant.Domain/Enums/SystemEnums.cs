namespace resturant.Domain.Enums;

public enum UserRole
{
    Admin,
    Customer,
    Manager,
    Waiter,
    Chef,
    DeliveryDriver,
}

public enum UserType
{
    Customer,
    Employee,
}

public enum OrderStatus
{
    Pending,
    Processing,
    Ready,
    Delivered,
    Cancelled,
}

public enum PaymentStatus
{
    Pending,
    Paid,
    Failed,
    Refunded,
}

public enum DeliveryStatus
{
    Pending,
    OnWay,
    Delivered,
    Failed,
}

public enum TableStatus
{
    Available,
    Occupied,
    Reserved,
    Dirty,
}

public enum TabletStatus
{
    Active,
    Maintenance,
    Lost,
}

public enum ScreenStatus
{
    Online,
    Offline,
    Maintenance,
}

public enum ShiftStatus
{
    Active,
    Completed,
    Cancelled,
}

public enum DeviceStatus
{
    Online,
    Offline,
    Maintenance,
    Lost,
}

public enum CashRegisterStatus
{
    Open,
    Closed,
    Suspended,
}

public enum TransactionType
{
    Sale,
    Refund,
    CashIn,
    CashOut,
    Expense,
}

public enum AccountType
{
    Asset,
    Liability,
    Income,
    Expense,
    Equity,
}

public enum OrderType
{
    DineIn,
    Takeout,
    Delivery,
}

public enum OrderSource
{
    Website,
    MobileApp,
    Tablet,
    Phone,
    InPerson,
}

public enum ReservationStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Completed,
    NoShow,
}

public enum ItemStatus
{
    Pending,
    Preparing,
    Ready,
    Served,
    Cancelled,
}
