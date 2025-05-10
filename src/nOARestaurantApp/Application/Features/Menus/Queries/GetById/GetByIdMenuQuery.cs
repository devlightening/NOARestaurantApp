using Application.Features.Menus.Constants;
using Application.Features.Menus.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Menus.Constants.MenusOperationClaims;

namespace Application.Features.Menus.Queries.GetById;

public class GetByIdMenuQuery : IRequest<GetByIdMenuResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMenuQueryHandler : IRequestHandler<GetByIdMenuQuery, GetByIdMenuResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;
        private readonly MenuBusinessRules _menuBusinessRules;

        public GetByIdMenuQueryHandler(IMapper mapper, IMenuRepository menuRepository, MenuBusinessRules menuBusinessRules)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
            _menuBusinessRules = menuBusinessRules;
        }

        public async Task<GetByIdMenuResponse> Handle(GetByIdMenuQuery request, CancellationToken cancellationToken)
        {
            Menu? menu = await _menuRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _menuBusinessRules.MenuShouldExistWhenSelected(menu);

            GetByIdMenuResponse response = _mapper.Map<GetByIdMenuResponse>(menu);
            return response;
        }
    }
}