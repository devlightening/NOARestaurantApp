using FluentValidation;

namespace Application.Features.Menus.Commands.Delete;

public class DeleteMenuCommandValidator : AbstractValidator<DeleteMenuCommand>
{
    public DeleteMenuCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}