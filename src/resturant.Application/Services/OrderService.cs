using Microsoft.EntityFrameworkCore;
using resturant.Domain.DTOs;
using resturant.Domain.Entities;
using resturant.Domain.Enums;
using resturant.Domain.Interfaces;

namespace resturant.Application.Services;

public interface IOrderService
{
    Task<OrderDto?> GetByIdAsync(long id);
    Task<IEnumerable<OrderDto>> GetByUserIdAsync(long userId);
    Task<IEnumerable<OrderDto>> GetByBranchIdAsync(long branchId, string? status = null);
    Task<OrderDto> CreateAsync(CreateOrderDto dto, long userId);
    Task UpdateStatusAsync(long orderId, OrderStatus status);
    Task CancelAsync(long orderId, string reason);
}

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OrderDto?> GetByIdAsync(long id)
    {
        var order = await _unitOfWork.Orders.FindAsync(o => o.OrderId == id);
        var entity = order.FirstOrDefault();
        if (entity == null) return null;

        return await MapToDto(entity);
    }

    public async Task<IEnumerable<OrderDto>> GetByUserIdAsync(long userId)
    {
        var orders = await _unitOfWork.Orders.FindAsync(o => o.AppUserId == userId);
        var result = new List<OrderDto>();
        foreach (var order in orders.OrderByDescending(o => o.OrderDate))
        {
            result.Add(await MapToDto(order));
        }
        return result;
    }

    public async Task<IEnumerable<OrderDto>> GetByBranchIdAsync(long branchId, string? status = null)
    {
        var orders = await _unitOfWork.Orders.FindAsync(o => o.BranchId == branchId);
        
        if (!string.IsNullOrEmpty(status) && Enum.TryParse<OrderStatus>(status, out var orderStatus))
        {
            orders = orders.Where(o => o.OrderStatus == orderStatus);
        }
        
        var result = new List<OrderDto>();
        foreach (var order in orders.OrderByDescending(o => o.OrderDate))
        {
            result.Add(await MapToDto(order));
        }
        return result;
    }

    public async Task<OrderDto> CreateAsync(CreateOrderDto dto, long userId)
    {
        // Calculate totals
        decimal totalAmount = 0;
        var orderItems = new List<OrderItem>();

        foreach (var item in dto.Items)
        {
            var menuItem = (await _unitOfWork.MenuItems.FindAsync(m => m.MenuItemId == item.MenuItemId)).FirstOrDefault();
            if (menuItem == null || !menuItem.IsAvailable)
                throw new InvalidOperationException($"Menu item {item.MenuItemId} not available");

            var subtotal = menuItem.Price * item.Quantity;
            totalAmount += subtotal;

            orderItems.Add(new OrderItem
            {
                MenuItemId = item.MenuItemId,
                Quantity = item.Quantity,
                UnitPrice = menuItem.Price,
                Subtotal = subtotal,
                SpecialInstructions = item.SpecialInstructions,
                ItemStatus = "Pending"
            });
        }

        // Apply discount if code provided
        decimal discountAmount = 0;
        if (!string.IsNullOrEmpty(dto.DiscountCode))
        {
            var discount = (await _unitOfWork.DiscountCodes.FindAsync(d => d.Code == dto.DiscountCode)).FirstOrDefault();
            if (discount != null && discount.IsActive && discount.ExpiryDate > DateTime.UtcNow)
            {
                if (discount.DiscountType == "Percentage")
                    discountAmount = totalAmount * discount.Value / 100;
                else
                    discountAmount = discount.Value;
            }
        }

        var taxAmount = (totalAmount - discountAmount) * 0.09m; // 9% tax
        var serviceCharge = (totalAmount - discountAmount) * 0.05m; // 5% service
        var finalAmount = totalAmount - discountAmount + taxAmount + serviceCharge;

        var order = new Order
        {
            AppUserId = userId,
            BranchId = dto.BranchId,
            TableId = dto.TableId,
            OrderType = dto.OrderType,
            OrderSource = dto.OrderSource,
            TotalAmount = totalAmount,
            DiscountAmount = discountAmount,
            TaxAmount = taxAmount,
            ServiceCharge = serviceCharge,
            FinalAmount = finalAmount,
            OrderStatus = OrderStatus.Pending,
            OrderDate = DateTime.UtcNow,
            Notes = dto.Notes,
            IsPaid = false
        };

        await _unitOfWork.Orders.AddAsync(order);

        // Add order items
        foreach (var item in orderItems)
        {
            item.OrderId = order.OrderId;
            await _unitOfWork.OrderItems.AddAsync(item);
        }

        return await MapToDto(order);
    }

    public async Task UpdateStatusAsync(long orderId, OrderStatus status)
    {
        var order = (await _unitOfWork.Orders.FindAsync(o => o.OrderId == orderId)).FirstOrDefault();
        if (order == null) throw new InvalidOperationException("Order not found");

        order.OrderStatus = status;
        await _unitOfWork.Orders.UpdateAsync(order);
    }

    public async Task CancelAsync(long orderId, string reason)
    {
        var order = (await _unitOfWork.Orders.FindAsync(o => o.OrderId == orderId)).FirstOrDefault();
        if (order == null) throw new InvalidOperationException("Order not found");

        if (order.OrderStatus == OrderStatus.Delivered || order.OrderStatus == OrderStatus.Cancelled)
            throw new InvalidOperationException("Cannot cancel this order");

        order.OrderStatus = OrderStatus.Cancelled;
        order.Notes = string.IsNullOrEmpty(order.Notes) 
            ? $"Cancelled: {reason}" 
            : $"{order.Notes}\nCancelled: {reason}";
        
        await _unitOfWork.Orders.UpdateAsync(order);
    }

    private async Task<OrderDto> MapToDto(Order order)
    {
        var user = (await _unitOfWork.AppUsers.FindAsync(u => u.AppUserId == order.AppUserId)).FirstOrDefault();
        var branch = (await _unitOfWork.Branches.FindAsync(b => b.BranchId == order.BranchId)).FirstOrDefault();
        var table = order.TableId.HasValue 
            ? (await _unitOfWork.Tables.FindAsync(t => t.TableId == order.TableId)).FirstOrDefault() 
            : null;
        var items = await _unitOfWork.OrderItems.FindAsync(oi => oi.OrderId == order.OrderId);

        var itemDtos = new List<OrderItemDto>();
        foreach (var item in items)
        {
            var menuItem = (await _unitOfWork.MenuItems.FindAsync(m => m.MenuItemId == item.MenuItemId)).FirstOrDefault();
            itemDtos.Add(new OrderItemDto
            {
                OrderItemId = item.OrderItemId,
                MenuItemId = item.MenuItemId,
                MenuItemName = menuItem?.ItemName,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Subtotal = item.Subtotal,
                SpecialInstructions = item.SpecialInstructions,
                ItemStatus = item.ItemStatus
            });
        }

        return new OrderDto
        {
            OrderId = order.OrderId,
            AppUserId = order.AppUserId,
            CustomerName = user != null ? $"{user.FirstName} {user.LastName}" : null,
            BranchId = order.BranchId,
            BranchName = branch?.BranchName,
            TableId = order.TableId,
            TableName = table?.TableName,
            OrderType = order.OrderType,
            OrderSource = order.OrderSource,
            TotalAmount = order.TotalAmount,
            DiscountAmount = order.DiscountAmount,
            TaxAmount = order.TaxAmount,
            ServiceCharge = order.ServiceCharge,
            FinalAmount = order.FinalAmount,
            OrderStatus = order.OrderStatus,
            OrderDate = order.OrderDate,
            EstimatedTime = order.EstimatedTime,
            ActualPrepTime = order.ActualPrepTime,
            Notes = order.Notes,
            IsPaid = order.IsPaid,
            Items = itemDtos
        };
    }
}
