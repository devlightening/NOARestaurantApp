using FluentValidation;

namespace Application.Features.Restaurants.Commands.Create;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.OpeningHours).NotEmpty();
        RuleFor(c => c.ClosingHours).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
        RuleFor(c => c.Photo).NotEmpty();
    }
}