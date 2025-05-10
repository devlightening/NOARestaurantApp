using FluentValidation;

namespace Application.Features.Employees.Commands.Update;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Surname).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Position).NotEmpty();
        RuleFor(c => c.RestaurantId).NotEmpty();
        RuleFor(c => c.Restaurant).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();

    }
}