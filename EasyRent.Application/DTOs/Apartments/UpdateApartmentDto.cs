namespace EasyRent.Application.DTOs.Apartments;

/// <summary>Write shape a landlord submits to update an existing listing.</summary>
public class UpdateApartmentDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public decimal PricePerNight { get; set; }
    public int Bedrooms { get; set; }
    public bool IsActive { get; set; } = true;
    public string? PhotoUrl { get; set; }
}
