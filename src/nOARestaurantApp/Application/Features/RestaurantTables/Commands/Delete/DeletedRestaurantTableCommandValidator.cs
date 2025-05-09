using FluentValidation;

namespace Application.Features.RestaurantTables.Commands.Delete;

public class DeleteRestaurantTableCommandValidator : AbstractValidator<DeleteRestaurantTableCommand>
{
    public DeleteRestaurantTableCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}