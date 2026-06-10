namespace EasyRent.Application.DTOs.Payments;

/// <summary>Read shape of a payment returned to clients.</summary>
public class PaymentDto
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public decimal Amount { get; set; }
    public string Method { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime PaidAt { get; set; }
}
