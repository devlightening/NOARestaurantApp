using FluentValidation;

namespace Application.Features.RestaurantTables.Commands.Update;

public class UpdateRestaurantTableCommandValidator : AbstractValidator<UpdateRestaurantTableCommand>
{
    public UpdateRestaurantTableCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.RestaurantId).NotEmpty();
        RuleFor(c => c.TableNumber).NotEmpty();
        RuleFor(c => c.Capacity).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
        RuleFor(c => c.IsAvailable).NotEmpty();
    }
}