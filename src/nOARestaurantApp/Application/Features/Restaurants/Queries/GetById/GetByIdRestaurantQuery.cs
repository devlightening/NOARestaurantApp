using Application.Features.Restaurants.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Restaurants.Queries.GetById;

public class GetByIdRestaurantQuery : IRequest<GetByIdRestaurantResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRestaurantQueryHandler : IRequestHandler<GetByIdRestaurantQuery, GetByIdRestaurantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly RestaurantBusinessRules _restaurantBusinessRules;

        public GetByIdRestaurantQueryHandler(IMapper mapper, IRestaurantRepository restaurantRepository, RestaurantBusinessRules restaurantBusinessRules)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _restaurantBusinessRules = restaurantBusinessRules;
        }

        public async Task<GetByIdRestaurantResponse> Handle(GetByIdRestaurantQuery request, CancellationToken cancellationToken)
        {
            Restaurant? restaurant = await _restaurantRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _restaurantBusinessRules.RestaurantShouldExistWhenSelected(restaurant);

            GetByIdRestaurantResponse response = _mapper.Map<GetByIdRestaurantResponse>(restaurant);
            return response;
        }
    }
}