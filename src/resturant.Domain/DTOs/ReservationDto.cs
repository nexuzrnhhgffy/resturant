using System;

namespace resturant.Domain.DTOs;

public class ReservationDto
{
    public long ReservationId { get; set; }
    public long AppUserId { get; set; }
    public string? CustomerName { get; set; }
    public long BranchId { get; set; }
    public string? BranchName { get; set; }
    public long TableId { get; set; }
    public string? TableName { get; set; }
    public DateTime ReservationDate { get; set; }
    public TimeSpan ReservationTime { get; set; }
    public int PartySize { get; set; }
    public string ReservationType { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? SpecialRequests { get; set; }
}

public class CreateReservationDto
{
    public long BranchId { get; set; }
    public long? TableId { get; set; }
    public DateTime ReservationDate { get; set; }
    public TimeSpan ReservationTime { get; set; }
    public int PartySize { get; set; }
    public string ReservationType { get; set; } = "DineIn";
    public string? SpecialRequests { get; set; }
}
