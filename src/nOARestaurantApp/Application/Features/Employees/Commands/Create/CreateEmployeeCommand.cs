using Application.Features.Employees.Constants;
using Application.Features.Employees.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.Employees.Constants.EmployeesOperationClaims;

namespace Application.Features.Employees.Commands.Create;

public class CreateEmployeeCommand : IRequest<CreatedEmployeeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Position { get; set; }
    public Guid RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public DateTime BirthDate { get; set; }

    public string[] Roles => [Admin, Write, EmployeesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEmployees"];

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreatedEmployeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeBusinessRules _employeeBusinessRules;

        public CreateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository,
                                         EmployeeBusinessRules employeeBusinessRules)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _employeeBusinessRules = employeeBusinessRules;
        }

        public async Task<CreatedEmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = _mapper.Map<Employee>(request);

            await _employeeRepository.AddAsync(employee);

            CreatedEmployeeResponse response = _mapper.Map<CreatedEmployeeResponse>(employee);
            return response;
        }
    }
}