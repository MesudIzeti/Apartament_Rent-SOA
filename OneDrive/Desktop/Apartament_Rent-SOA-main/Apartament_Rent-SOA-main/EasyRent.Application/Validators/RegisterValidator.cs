using EasyRent.Application.DTOs.Auth;
using FluentValidation;

namespace EasyRent.Application.Validators;

/// <summary>Validation rules for user registration.</summary>
public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6)
            .WithMessage("Password must be at least 6 characters.");
        RuleFor(x => x.Role).NotEmpty()
            .Must(r => r is "Landlord" or "Tenant")
            .WithMessage("Role must be either 'Landlord' or 'Tenant'.");
    }
}
