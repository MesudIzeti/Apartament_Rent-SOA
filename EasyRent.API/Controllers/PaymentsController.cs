using EasyRent.Application.DTOs.Payments;
using EasyRent.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EasyRent.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    // POST /api/payments  (Tenant pays for an approved booking)
    [HttpPost]
    [Authorize(Roles = "Tenant")]
    public async Task<IActionResult> Pay([FromBody] CreatePaymentDto dto)
    {
        var tenantId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        // PayAsync(string tenantId, CreatePaymentDto dto)
        var result = await _paymentService.PayAsync(tenantId, dto);
        return Ok(result);
    }

    // GET /api/payments/mine  (Tenant sees own payment history)
    [HttpGet("mine")]
    [Authorize(Roles = "Tenant")]
    public async Task<IActionResult> GetMine()
    {
        var tenantId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        // GetMineAsync(string tenantId)
        var result = await _paymentService.GetMineAsync(tenantId);
        return Ok(result);
    }
}