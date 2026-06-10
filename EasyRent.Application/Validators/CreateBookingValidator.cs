using EasyRent.Application.DTOs.Bookings;
using FluentValidation;

namespace EasyRent.Application.Validators;

/// <summary>Validation rules for creating a booking. (Date-overlap availability is a
/// business rule checked in the service against the database, not here.)</summary>
public class CreateBookingValidator : AbstractValidator<CreateBookingDto>
{
    public CreateBookingValidator()
    {
        RuleFor(x => x.ApartmentId).GreaterThan(0);
        RuleFor(x => x.CheckIn).NotEmpty();
        RuleFor(x => x.CheckOut).NotEmpty()
            .GreaterThan(x => x.CheckIn)
            .WithMessage("CheckOut must be after CheckIn.");
    }
}
