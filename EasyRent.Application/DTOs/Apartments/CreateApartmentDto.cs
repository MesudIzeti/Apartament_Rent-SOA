namespace EasyRent.Application.DTOs.Apartments;

/// <summary>Write shape a landlord submits to create a listing. No Id/LandlordId — the
/// server sets the owner from the authenticated user.</summary>
public class CreateApartmentDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public decimal PricePerNight { get; set; }
    public int Bedrooms { get; set; }
    public string? PhotoUrl { get; set; }
}
