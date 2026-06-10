namespace EasyRent.Application.DTOs.Bookings;

/// <summary>Read shape of a booking returned to clients. Status is exposed as a
/// readable string (e.g. "Pending") rather than the raw enum number.</summary>
public class BookingDto
{
    public int Id { get; set; }
    public int ApartmentId { get; set; }
    public string ApartmentTitle { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
