using Application.Features.Employees.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

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

    public async Task EmployeeNameMustBeUnique(string name)
    {
        var existing = await _employeeRepository.GetAsync(e => e.Name == name);
        if(existing !=null)
            throw new BusinessException(EmployeesBusinessMessages.EmployeeNameMustBeUnique);

    }
    public async Task EmployeeSurnameMustBeUnique(string surname) 
    {
        var existing = await _employeeRepository.GetAsync(e => e.Surname == surname);
        if (existing != null)
            throw new  BusinessException(EmployeesBusinessMessages.EmployeeSurnameMustBeUnique);
    }

    public async Task EmployeePhoneNumberMustBeUnique(string phoneNumber)
    {
        var existing = await _employeeRepository.GetAsync(e => e.PhoneNumber == phoneNumber);
        if(existing != null)
            throw new BusinessException(EmployeesBusinessMessages.EmployeePhoneNumberMustBeUnique);
    }

    public async Task EmployeeEmailMustBeUnique(string email)
    {
        var existing = await _employeeRepository.GetAsync(e => e.Email == email);
        if (existing != null)
            throw new BusinessException(EmployeesBusinessMessages.EmployeeEmailMustBeUnique);

    }
    public async Task EmployeeCannotBeAssignedToMultipleRestaurants(string email , Guid restaurantId)
    {
        var existng = await _employeeRepository.GetAsync(e => e.Email == email && e.RestaurantId == restaurantId);
        if (existng != null)
            throw new BusinessException(EmployeesBusinessMessages.EmployeeCannotBeAssignedToMultipleRestaurants);
    }

    public  Task EmployeeMustBeAtLeast18YearsOld(DateTime birthDate)
    {
        int age = DateTime.Now.Year - birthDate.Year;
        if (birthDate.Date > DateTime.Now.AddYears(-age)) age--; //doðum günü geçmemiþse yaþý bir azalt 
        if(age<18)
            throw new BusinessException(EmployeesBusinessMessages.EmployeeMustBeAtLeast18YearsOld);
        return Task.CompletedTask;
    }



}