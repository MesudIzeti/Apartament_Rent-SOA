using EasyRent.Application.DTOs.Payments;
using EasyRent.Domain.Entities;

namespace EasyRent.Application.Mapping;

/// <summary>Manual Entity → DTO conversion for payments.</summary>
public static class PaymentMappings
{
    public static PaymentDto ToDto(this Payment p) => new()
    {
        Id = p.Id,
        BookingId = p.BookingId,
        Amount = p.Amount,
        Method = p.Method,
        Status = p.Status.ToString(),
        PaidAt = p.PaidAt
    };
}
