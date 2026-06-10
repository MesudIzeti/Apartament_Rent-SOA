using EasyRent.Application.DTOs.Apartments;
using EasyRent.Application.DTOs.Common;

namespace EasyRent.Application.Interfaces.Services;

/// <summary>Apartment use-cases. Ownership is enforced inside the implementation:
/// only the owning landlord (or an admin) may modify a listing.</summary>
public interface IApartmentService
{
    Task<PagedResult<ApartmentDto>> SearchAsync(ApartmentSearchDto search);
    Task<ApartmentDto> GetByIdAsync(int id);
    Task<ApartmentDto> CreateAsync(string landlordId, CreateApartmentDto dto);
    Task<ApartmentDto> UpdateAsync(string landlordId, int id, UpdateApartmentDto dto);
    Task DeleteAsync(string requestingUserId, bool isAdmin, int id);
}
