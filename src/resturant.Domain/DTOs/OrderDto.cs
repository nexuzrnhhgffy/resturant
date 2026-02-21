using System;
using System.Collections.Generic;
using resturant.Domain.Enums;

namespace resturant.Domain.DTOs;

public class OrderDto
{
    public long OrderId { get; set; }
    public long AppUserId { get; set; }
    public string? CustomerName { get; set; }
    public long BranchId { get; set; }
    public string? BranchName { get; set; }
    public long? TableId { get; set; }
    public string? TableName { get; set; }
    public string OrderType { get; set; } = string.Empty;
    public string OrderSource { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal ServiceCharge { get; set; }
    public decimal FinalAmount { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime OrderDate { get; set; }
    public int? EstimatedTime { get; set; }
    public int? ActualPrepTime { get; set; }
    public string? Notes { get; set; }
    public bool IsPaid { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}

public class OrderItemDto
{
    public long OrderItemId { get; set; }
    public long MenuItemId { get; set; }
    public string? MenuItemName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal { get; set; }
    public string? SpecialInstructions { get; set; }
    public string? ItemStatus { get; set; }
}

public class CreateOrderDto
{
    public long BranchId { get; set; }
    public long? TableId { get; set; }
    public string OrderType { get; set; } = "DineIn";
    public string OrderSource { get; set; } = "Website";
    public string? Notes { get; set; }
    public List<CreateOrderItemDto> Items { get; set; } = new();
    public string? DiscountCode { get; set; }
}

public class CreateOrderItemDto
{
    public long MenuItemId { get; set; }
    public int Quantity { get; set; }
    public string? SpecialInstructions { get; set; }
    public List<long> ModifierIds { get; set; } = new();
}
