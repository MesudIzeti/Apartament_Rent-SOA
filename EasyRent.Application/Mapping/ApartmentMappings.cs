using EasyRent.Application.DTOs.Apartments;
using EasyRent.Domain.Entities;

namespace EasyRent.Application.Mapping;

/// <summary>Manual Entity ⇄ DTO conversions for apartments (no AutoMapper dependency).</summary>
public static class ApartmentMappings
{
    /// <summary>Entity → read DTO.</summary>
    public static ApartmentDto ToDto(this Apartment a) => new()
    {
        Id = a.Id,
        Title = a.Title,
        Description = a.Description,
        Address = a.Address,
        City = a.City,
        PricePerNight = a.PricePerNight,
        Bedrooms = a.Bedrooms,
        IsActive = a.IsActive,
        PhotoUrl = a.PhotoUrl,
        LandlordId = a.LandlordId
    };

    /// <summary>Create DTO → new entity, with the owner set from the authenticated user.</summary>
    public static Apartment ToEntity(this CreateApartmentDto dto, string landlordId) => new()
    {
        Title = dto.Title,
        Description = dto.Description,
        Address = dto.Address,
        City = dto.City,
        PricePerNight = dto.PricePerNight,
        Bedrooms = dto.Bedrooms,
        PhotoUrl = dto.PhotoUrl,
        LandlordId = landlordId,
        IsActive = true
    };

    /// <summary>Apply an update DTO onto an existing tracked entity.</summary>
    public static void ApplyTo(this UpdateApartmentDto dto, Apartment a)
    {
        a.Title = dto.Title;
        a.Description = dto.Description;
        a.Address = dto.Address;
        a.City = dto.City;
        a.PricePerNight = dto.PricePerNight;
        a.Bedrooms = dto.Bedrooms;
        a.IsActive = dto.IsActive;
        a.PhotoUrl = dto.PhotoUrl;
    }
}
