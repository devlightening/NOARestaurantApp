using Application.Features.Employees.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Application.Features.Employees.Rules;

public class EmployeeBusinessRules : BaseBusinessRules
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ILocalizationService _localizationService;

    public EmployeeBusinessRules(IEmployeeRepository employeeRepository, ILocalizationService localizationService)
    {
        _employeeRepository = employeeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, EmployeesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task EmployeeShouldExistWhenSelected(Employee? employee)
    {
        if (employee == null)
            await throwBusinessException(EmployeesBusinessMessages.EmployeeNotExists);
    }

    public async Task EmployeeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Employee? employee = await _employeeRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EmployeeShouldExistWhenSelected(employee);
    }

    public async Task EmployeePhoneNumberShouldBeUnique(string phoneNumber, CancellationToken cancellationToken)
    {
        bool phoneNumberExists = await _employeeRepository
            .Query()
            .AnyAsync(e => e.PhoneNumber == phoneNumber, cancellationToken);

        if (phoneNumberExists)
            throw new BusinessException(EmployeesBusinessMessages.EmployeePhoneNumberShouldBeUnique);
    }

    public async Task EmployeeEmailShouldBeUnique(string email, CancellationToken cancellationToken)
    {
        bool emailExists = await _employeeRepository.Query().
            AnyAsync(e => e.Email == email, cancellationToken);
        if (emailExists)
            throw new BusinessException(EmployeesBusinessMessages.EmployeeEmailShouldBeUnique);
    }
    public Task PhoneNumberFormatMustBeValid(string phoneNumber)
    {
        if (!Regex.IsMatch(phoneNumber, @"^05\d{9}$"))
            throw new BusinessException(EmployeesBusinessMessages.EmployeePhoneNumberFormatInvalid);
        return Task.CompletedTask;
    }
    public Task EmailFormatMustBeValid(string email)
    {
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new BusinessException(EmployeesBusinessMessages.EmployeeEmailFormatInvalid);
        return Task.CompletedTask;
    }

    public void EmployeePositionMustBeValid(string position)
    {
        bool isValid = Enum.GetNames(typeof(EmployeePosition)).Contains(position);
        if (!isValid)
            throw new BusinessException(EmployeesBusinessMessages.EmployeePositionInValid);
    }


}