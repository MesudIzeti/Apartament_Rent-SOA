namespace EasyRent.Application.DTOs.Bookings;

/// <summary>What a tenant submits to request a booking. The price is NOT here —
/// the server computes it from the apartment to prevent client tampering.</summary>
public class CreateBookingDto
{
    public int ApartmentId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
}
