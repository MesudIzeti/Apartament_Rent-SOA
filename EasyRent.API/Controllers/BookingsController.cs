using EasyRent.Application.DTOs.Bookings;
using EasyRent.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EasyRent.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    // POST /api/bookings  (Tenant creates a booking)
    [HttpPost]
    [Authorize(Roles = "Tenant")]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto dto)
    {
        var tenantId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        // CreateAsync(string tenantId, CreateBookingDto dto)
        var result = await _bookingService.CreateAsync(tenantId, dto);
        return Ok(result);
    }

    // GET /api/bookings/mine  (Tenant sees own bookings)
    [HttpGet("mine")]
    [Authorize(Roles = "Tenant")]
    public async Task<IActionResult> GetMine()
    {
        var tenantId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        // GetMineAsync(string tenantId)
        var result = await _bookingService.GetMineAsync(tenantId);
        return Ok(result);
    }

    // GET /api/bookings/incoming  (Landlord sees bookings for their apartments)
    [HttpGet("incoming")]
    [Authorize(Roles = "Landlord")]
    public async Task<IActionResult> GetIncoming()
    {
        var landlordId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        // GetIncomingAsync(string landlordId)
        var result = await _bookingService.GetIncomingAsync(landlordId);
        return Ok(result);
    }

    // PUT /api/bookings/{id}/approve  (Landlord approves)
    [HttpPut("{id}/approve")]
    [Authorize(Roles = "Landlord")]
    public async Task<IActionResult> Approve(int id)
    {
        var landlordId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        // ApproveAsync(string landlordId, int bookingId)
        var result = await _bookingService.ApproveAsync(landlordId, id);
        return Ok(result);
    }

    // PUT /api/bookings/{id}/reject  (Landlord rejects)
    [HttpPut("{id}/reject")]
    [Authorize(Roles = "Landlord")]
    public async Task<IActionResult> Reject(int id)
    {
        var landlordId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        // RejectAsync(string landlordId, int bookingId)
        var result = await _bookingService.RejectAsync(landlordId, id);
        return Ok(result);
    }

    // PUT /api/bookings/{id}/cancel  (Tenant cancels own booking)
    [HttpPut("{id}/cancel")]
    [Authorize(Roles = "Tenant")]
    public async Task<IActionResult> Cancel(int id)
    {
        var tenantId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        // CancelAsync(string tenantId, int bookingId)
        var result = await _bookingService.CancelAsync(tenantId, id);
        return Ok(result);
    }
}