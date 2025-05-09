using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.RestaurantTables.Queries.GetList;

public class GetListRestaurantTableQuery : IRequest<GetListResponse<GetListRestaurantTableListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRestaurantTableQueryHandler : IRequestHandler<GetListRestaurantTableQuery, GetListResponse<GetListRestaurantTableListItemDto>>
    {
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        private readonly IMapper _mapper;

        public GetListRestaurantTableQueryHandler(IRestaurantTableRepository restaurantTableRepository, IMapper mapper)
        {
            _restaurantTableRepository = restaurantTableRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRestaurantTableListItemDto>> Handle(GetListRestaurantTableQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RestaurantTable> restaurantTables = await _restaurantTableRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRestaurantTableListItemDto> response = _mapper.Map<GetListResponse<GetListRestaurantTableListItemDto>>(restaurantTables);
            return response;
        }
    }
}