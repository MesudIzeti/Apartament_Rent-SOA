using EasyRent.Application.DTOs.Apartments;
using EasyRent.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EasyRent.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApartmentsController : ControllerBase
{
    private readonly IApartmentService _apartmentService;

    public ApartmentsController(IApartmentService apartmentService)
    {
        _apartmentService = apartmentService;
    }

    // GET /api/apartments?city=...&minPrice=...&page=1&pageSize=10  (public)
    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] ApartmentSearchDto search)
    {
        var result = await _apartmentService.SearchAsync(search);
        return Ok(result);
    }

    // GET /api/apartments/{id}  (public)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var apartment = await _apartmentService.GetByIdAsync(id);
        return Ok(apartment);
    }

    // POST /api/apartments  (Landlord only)
    [HttpPost]
    [Authorize(Roles = "Landlord")]
    public async Task<IActionResult> Create([FromBody] CreateApartmentDto dto)
    {
        var landlordId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var result = await _apartmentService.CreateAsync(landlordId, dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    // PUT /api/apartments/{id}  (Landlord only, must own it)
    [HttpPut("{id}")]
    [Authorize(Roles = "Landlord")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateApartmentDto dto)
    {
        var landlordId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        // UpdateAsync(string landlordId, int id, UpdateApartmentDto dto)
        var result = await _apartmentService.UpdateAsync(landlordId, id, dto);
        return Ok(result);
    }

    // DELETE /api/apartments/{id}  (Landlord owns it, or Admin)
    [HttpDelete("{id}")]
    [Authorize(Roles = "Landlord,Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId  = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var isAdmin = User.IsInRole("Admin");
        // DeleteAsync(string requestingUserId, bool isAdmin, int id)
        await _apartmentService.DeleteAsync(userId, isAdmin, id);
        return NoContent();
    }
}