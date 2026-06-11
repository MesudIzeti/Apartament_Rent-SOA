using EasyRent.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EasyRent.Domain.Entities;

namespace EasyRent.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(IBookingService bookingService, UserManager<ApplicationUser> userManager)
    {
        _bookingService = bookingService;
        _userManager = userManager;
    }

    // GET /api/admin/users
    [HttpGet("users")]
    public IActionResult GetUsers()
    {
        var users = _userManager.Users
            .Select(u => new { u.Id, u.FullName, u.Email })
            .ToList();
        return Ok(users);
    }

    // GET /api/admin/bookings  — reuses IBookingService, no extra interface method needed
    // We need all bookings; add GetAllAsync to IBookingService if not present,
    // OR query via UserManager. Since the plan says Admin sees /bookings,
    // the cleanest fix is a dedicated admin method. Add this to IBookingService:
    //   Task<IEnumerable<BookingDto>> GetAllAsync();
    // Then implement in BookingService (return all, no filter).
    [HttpGet("bookings")]
    public async Task<IActionResult> GetAllBookings()
    {
        var result = await _bookingService.GetAllAsync();
        return Ok(result);
    }
}