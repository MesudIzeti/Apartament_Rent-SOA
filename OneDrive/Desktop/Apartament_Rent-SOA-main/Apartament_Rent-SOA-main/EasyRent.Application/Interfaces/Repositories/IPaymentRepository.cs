using EasyRent.Domain.Entities;

namespace EasyRent.Application.Interfaces.Repositories;

/// <summary>Payment-specific queries on top of the generic CRUD contract.</summary>
public interface IPaymentRepository : IGenericRepository<Payment>
{
    /// <summary>All payments made by a given tenant (joined through their bookings).</summary>
    Task<IEnumerable<Payment>> GetByTenantAsync(string tenantId);
}
