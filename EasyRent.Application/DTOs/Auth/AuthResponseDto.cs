namespace EasyRent.Application.DTOs.Auth;

/// <summary>What the API returns after a successful register/login.</summary>
public class AuthResponseDto
{
    /// <summary>The signed JWT the client sends on every subsequent request.</summary>
    public string Token { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
}
