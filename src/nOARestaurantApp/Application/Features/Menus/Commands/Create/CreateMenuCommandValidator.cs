using FluentValidation;

namespace Application.Features.Menus.Commands.Create;

public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.RestaurantId).NotEmpty();
        RuleFor(c => c.Photo).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
        RuleFor(c => c.Restaurant).NotEmpty();
    }
}