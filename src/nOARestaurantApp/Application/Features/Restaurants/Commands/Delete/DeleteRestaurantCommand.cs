using Application.Features.Restaurants.Constants;
using Application.Features.Restaurants.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Restaurants.Commands.Delete;

public class DeleteRestaurantCommand : IRequest<DeletedRestaurantResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRestaurants"];

    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, DeletedRestaurantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly RestaurantBusinessRules _restaurantBusinessRules;

        public DeleteRestaurantCommandHandler(IMapper mapper, IRestaurantRepository restaurantRepository,
                                         RestaurantBusinessRules restaurantBusinessRules)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _restaurantBusinessRules = restaurantBusinessRules;
        }

        public async Task<DeletedRestaurantResponse> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            Restaurant? restaurant = await _restaurantRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _restaurantBusinessRules.RestaurantShouldExistWhenSelected(restaurant);

            await _restaurantRepository.DeleteAsync(restaurant!);

            DeletedRestaurantResponse response = _mapper.Map<DeletedRestaurantResponse>(restaurant);
            return response;
        }
    }
}