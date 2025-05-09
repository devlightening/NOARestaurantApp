using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Restaurants.Queries.GetList;

public class GetListRestaurantQuery : IRequest<GetListResponse<GetListRestaurantListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListRestaurants({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetRestaurants";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRestaurantQueryHandler : IRequestHandler<GetListRestaurantQuery, GetListResponse<GetListRestaurantListItemDto>>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public GetListRestaurantQueryHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRestaurantListItemDto>> Handle(GetListRestaurantQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Restaurant> restaurants = await _restaurantRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRestaurantListItemDto> response = _mapper.Map<GetListResponse<GetListRestaurantListItemDto>>(restaurants);
            return response;
        }
    }
}