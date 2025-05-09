using Application.Features.Restaurants.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Restaurants.Commands.Create;

public class CreateRestaurantCommand : IRequest<CreatedRestaurantResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string OpeningHours { get; set; }
    public string ClosingHours { get; set; }
    public string Location { get; set; }
    public string? Photo { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRestaurants"];

    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, CreatedRestaurantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly RestaurantBusinessRules _restaurantBusinessRules;

        public CreateRestaurantCommandHandler(IMapper mapper, IRestaurantRepository restaurantRepository,
                                         RestaurantBusinessRules restaurantBusinessRules)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _restaurantBusinessRules = restaurantBusinessRules;
        }

        public async Task<CreatedRestaurantResponse> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {

            await _restaurantBusinessRules.PhoneNumberCannotBeDuplicatedWhenInserted(request.PhoneNumber);
            await _restaurantBusinessRules.RestaurantNameCannotBeDuplicatedInSameLocation(request.Name, request.Location);
            _restaurantBusinessRules.LocationCannotBeEmpty(request.Location);


            Restaurant restaurant = _mapper.Map<Restaurant>(request);

            await _restaurantRepository.AddAsync(restaurant);

            CreatedRestaurantResponse response = _mapper.Map<CreatedRestaurantResponse>(restaurant);
            return response;
        }

 
    }
}