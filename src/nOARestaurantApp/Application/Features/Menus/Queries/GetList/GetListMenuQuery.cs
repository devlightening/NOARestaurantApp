using Application.Features.Menus.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Menus.Constants.MenusOperationClaims;

namespace Application.Features.Menus.Queries.GetList;

public class GetListMenuQuery : IRequest<GetListResponse<GetListMenuListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListMenus({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetMenus";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMenuQueryHandler : IRequestHandler<GetListMenuQuery, GetListResponse<GetListMenuListItemDto>>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public GetListMenuQueryHandler(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMenuListItemDto>> Handle(GetListMenuQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Menu> menus = await _menuRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMenuListItemDto> response = _mapper.Map<GetListResponse<GetListMenuListItemDto>>(menus);
            return response;
        }
    }
}