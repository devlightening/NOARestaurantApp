using Application.Features.Menus.Constants;
using Application.Features.Menus.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.Menus.Constants.MenusOperationClaims;

namespace Application.Features.Menus.Commands.Create;

public class CreateMenuCommand : IRequest<CreatedMenuResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Photo { get; set; }
    public Guid RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }

    public string[] Roles => [Admin, Write, MenusOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMenus"];

    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, CreatedMenuResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;
        private readonly MenuBusinessRules _menuBusinessRules;

        public CreateMenuCommandHandler(IMapper mapper, IMenuRepository menuRepository,
                                         MenuBusinessRules menuBusinessRules)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
            _menuBusinessRules = menuBusinessRules;
        }

        public async Task<CreatedMenuResponse> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            Menu menu = _mapper.Map<Menu>(request);

            await _menuRepository.AddAsync(menu);

            CreatedMenuResponse response = _mapper.Map<CreatedMenuResponse>(menu);
            return response;
        }
    }
}