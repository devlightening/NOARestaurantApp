using Application.Features.Restaurants.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Restaurants.Commands.Update;

public class UpdateRestaurantCommand : IRequest<UpdatedRestaurantResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
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

    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, UpdatedRestaurantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly RestaurantBusinessRules _restaurantBusinessRules;

        public UpdateRestaurantCommandHandler(IMapper mapper, IRestaurantRepository restaurantRepository,
                                         RestaurantBusinessRules restaurantBusinessRules)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _restaurantBusinessRules = restaurantBusinessRules;
        }

        public async Task<UpdatedRestaurantResponse> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            Restaurant? restaurant = await _restaurantRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _restaurantBusinessRules.RestaurantShouldExistWhenSelected(restaurant);
            restaurant = _mapper.Map(request, restaurant);

            await _restaurantRepository.UpdateAsync(restaurant!);

            UpdatedRestaurantResponse response = _mapper.Map<UpdatedRestaurantResponse>(restaurant);
            return response;
        }
    }
}