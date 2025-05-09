using FluentValidation;

namespace Application.Features.RestaurantTables.Commands.Create;

public class CreateRestaurantTableCommandValidator : AbstractValidator<CreateRestaurantTableCommand>
{
    public CreateRestaurantTableCommandValidator()
    {
        RuleFor(c => c.RestaurantId).NotEmpty();
        RuleFor(c => c.TableNumber).NotEmpty();
        RuleFor(c => c.Capacity).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
        RuleFor(c => c.IsAvailable).NotEmpty();
    }
}