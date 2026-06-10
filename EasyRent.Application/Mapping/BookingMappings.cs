using EasyRent.Application.DTOs.Bookings;
using EasyRent.Domain.Entities;

namespace EasyRent.Application.Mapping;

/// <summary>Manual Entity → DTO conversion for bookings.</summary>
public static class BookingMappings
{
    /// <summary>Entity → read DTO. ApartmentTitle is read from the loaded navigation if present.</summary>
    public static BookingDto ToDto(this Booking b) => new()
    {
        Id = b.Id,
        ApartmentId = b.ApartmentId,
        ApartmentTitle = b.Apartment?.Title ?? string.Empty,
        TenantId = b.TenantId,
        CheckIn = b.CheckIn,
        CheckOut = b.CheckOut,
        TotalPrice = b.TotalPrice,
        Status = b.Status.ToString(),
        CreatedAt = b.CreatedAt
    };
}
