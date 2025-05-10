using Application.Features.Menus.Constants;
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

namespace Application.Features.Menus.Commands.Delete;

public class DeleteMenuCommand : IRequest<DeletedMenuResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, MenusOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMenus"];

    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, DeletedMenuResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;
        private readonly MenuBusinessRules _menuBusinessRules;

        public DeleteMenuCommandHandler(IMapper mapper, IMenuRepository menuRepository,
                                         MenuBusinessRules menuBusinessRules)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
            _menuBusinessRules = menuBusinessRules;
        }

        public async Task<DeletedMenuResponse> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            Menu? menu = await _menuRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _menuBusinessRules.MenuShouldExistWhenSelected(menu);

            await _menuRepository.DeleteAsync(menu!);

            DeletedMenuResponse response = _mapper.Map<DeletedMenuResponse>(menu);
            return response;
        }
    }
}