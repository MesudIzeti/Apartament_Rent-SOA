namespace EasyRent.Application.DTOs.Auth;

/// <summary>Credentials a user submits to log in.</summary>
public class LoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
