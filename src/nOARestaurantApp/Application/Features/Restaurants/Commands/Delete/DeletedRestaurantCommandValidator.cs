using FluentValidation;

namespace Application.Features.Restaurants.Commands.Delete;

public class DeleteRestaurantCommandValidator : AbstractValidator<DeleteRestaurantCommand>
{
    public DeleteRestaurantCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}