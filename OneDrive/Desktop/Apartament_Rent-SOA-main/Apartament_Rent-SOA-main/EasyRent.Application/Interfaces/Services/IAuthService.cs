using EasyRent.Application.DTOs.Auth;

namespace EasyRent.Application.Interfaces.Services;

/// <summary>Registration and login. Returns a JWT on success.</summary>
public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
    Task<AuthResponseDto> LoginAsync(LoginDto dto);
}
