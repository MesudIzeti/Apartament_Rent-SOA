namespace EasyRent.Application.DTOs.Apartments;

/// <summary>Read shape of an apartment returned to clients.</summary>
public class ApartmentDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public decimal PricePerNight { get; set; }
    public int Bedrooms { get; set; }
    public bool IsActive { get; set; }
    public string? PhotoUrl { get; set; }
    public string LandlordId { get; set; } = string.Empty;
}
