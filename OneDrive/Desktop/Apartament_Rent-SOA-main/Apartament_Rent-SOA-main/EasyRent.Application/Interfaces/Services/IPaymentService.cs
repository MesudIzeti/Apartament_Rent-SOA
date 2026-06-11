using EasyRent.Application.DTOs.Payments;

namespace EasyRent.Application.Interfaces.Services;

/// <summary>Payment use-cases. Paying is only allowed on an Approved booking and
/// atomically flips the booking to Paid.</summary>
public interface IPaymentService
{
    Task<PaymentDto> PayAsync(string tenantId, CreatePaymentDto dto);
    Task<IEnumerable<PaymentDto>> GetMineAsync(string tenantId);
}
