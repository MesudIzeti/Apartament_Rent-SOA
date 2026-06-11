using EasyRent.Application.DTOs.Apartments;
using FluentValidation;

namespace EasyRent.Application.Validators;

/// <summary>Validation rules for creating an apartment listing.</summary>
public class CreateApartmentValidator : AbstractValidator<CreateApartmentDto>
{
    public CreateApartmentValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Address).NotEmpty().MaximumLength(250);
        RuleFor(x => x.City).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PricePerNight).GreaterThan(0)
            .WithMessage("Price per night must be greater than 0.");
        RuleFor(x => x.Bedrooms).GreaterThan(0);
    }
}
