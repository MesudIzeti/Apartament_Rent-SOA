using EasyRent.Domain.Entities;

namespace EasyRent.Application.Interfaces.Services;

/// <summary>Builds signed JWT access tokens for authenticated users.</summary>
public interface ITokenService
{
    /// <summary>Creates a JWT for the user carrying their id and role, plus its expiry time.</summary>
    (string Token, DateTime ExpiresAt) CreateToken(ApplicationUser user, string role);
}
