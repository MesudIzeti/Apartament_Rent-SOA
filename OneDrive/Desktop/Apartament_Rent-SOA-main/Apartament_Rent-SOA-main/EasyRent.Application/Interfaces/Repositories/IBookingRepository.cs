using EasyRent.Domain.Entities;

namespace EasyRent.Application.Interfaces.Repositories;

/// <summary>Booking-specific queries on top of the generic CRUD contract.</summary>
public interface IBookingRepository : IGenericRepository<Booking>
{
    /// <summary>True if an Approved/Paid booking already overlaps the given dates for this apartment.</summary>
    Task<bool> HasOverlapAsync(int apartmentId, DateTime checkIn, DateTime checkOut);

    /// <summary>All bookings made by a given tenant.</summary>
    Task<IEnumerable<Booking>> GetByTenantAsync(string tenantId);

    /// <summary>All bookings on apartments owned by a given landlord (incoming requests).</summary>
    Task<IEnumerable<Booking>> GetIncomingForLandlordAsync(string landlordId);
}
