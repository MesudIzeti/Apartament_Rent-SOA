using EasyRent.Application.DTOs.Bookings;

namespace EasyRent.Application.Interfaces.Services;

/// <summary>Booking use-cases. The implementation enforces the booking state machine,
/// availability (overlap) checks, server-side pricing, and ownership rules.</summary>
public interface IBookingService
{
    Task<BookingDto> CreateAsync(string tenantId, CreateBookingDto dto);
    Task<IEnumerable<BookingDto>> GetMineAsync(string tenantId);
    Task<IEnumerable<BookingDto>> GetIncomingAsync(string landlordId);
    Task<BookingDto> ApproveAsync(string landlordId, int bookingId);
    Task<BookingDto> RejectAsync(string landlordId, int bookingId);
    Task<BookingDto> CancelAsync(string tenantId, int bookingId);
    Task<IEnumerable<BookingDto>> GetAllAsync();
}
