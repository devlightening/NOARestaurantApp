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

namespace Application.Features.Menus.Commands.Update;

public class UpdateMenuCommand : IRequest<UpdatedMenuResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Photo { get; set; }
    public Guid RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }

    public string[] Roles => [Admin, Write, MenusOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMenus"];

    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, UpdatedMenuResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;
        private readonly MenuBusinessRules _menuBusinessRules;

        public UpdateMenuCommandHandler(IMapper mapper, IMenuRepository menuRepository,
                                         MenuBusinessRules menuBusinessRules)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
            _menuBusinessRules = menuBusinessRules;
        }

        public async Task<UpdatedMenuResponse> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            Menu? menu = await _menuRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _menuBusinessRules.MenuShouldExistWhenSelected(menu);
            menu = _mapper.Map(request, menu);

            await _menuRepository.UpdateAsync(menu!);

            UpdatedMenuResponse response = _mapper.Map<UpdatedMenuResponse>(menu);
            return response;
        }
    }
}