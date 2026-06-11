namespace EasyRent.Application.DTOs.Auth;

/// <summary>Data a new user submits to register.</summary>
public class RegisterDto
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    /// <summary>Either "Landlord" or "Tenant". Admin accounts are seeded, not self-registered.</summary>
    public string Role { get; set; } = string.Empty;
}
