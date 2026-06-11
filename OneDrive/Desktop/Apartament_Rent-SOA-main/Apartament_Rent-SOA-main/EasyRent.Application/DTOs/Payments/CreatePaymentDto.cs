namespace EasyRent.Application.DTOs.Payments;

/// <summary>What a tenant submits to pay an approved booking. The amount is NOT here —
/// the server takes it from the booking's total.</summary>
public class CreatePaymentDto
{
    public int BookingId { get; set; }
    public string Method { get; set; } = "DirectDebit";
}
