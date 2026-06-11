using EasyRent.Application.DTOs.Apartments;
using EasyRent.Domain.Entities;

namespace EasyRent.Application.Interfaces.Repositories;

/// <summary>Apartment-specific queries on top of the generic CRUD contract.</summary>
public interface IApartmentRepository : IGenericRepository<Apartment>
{
    /// <summary>Returns a filtered, paginated page of apartments plus the total match count.</summary>
    Task<(IEnumerable<Apartment> Items, int TotalCount)> SearchAsync(ApartmentSearchDto search);

    /// <summary>All apartments owned by a given landlord.</summary>
    Task<IEnumerable<Apartment>> GetByLandlordAsync(string landlordId);
}
