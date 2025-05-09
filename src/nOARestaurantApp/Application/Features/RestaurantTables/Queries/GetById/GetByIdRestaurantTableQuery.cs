using Application.Features.RestaurantTables.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RestaurantTables.Queries.GetById;

public class GetByIdRestaurantTableQuery : IRequest<GetByIdRestaurantTableResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRestaurantTableQueryHandler : IRequestHandler<GetByIdRestaurantTableQuery, GetByIdRestaurantTableResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        private readonly RestaurantTableBusinessRules _restaurantTableBusinessRules;

        public GetByIdRestaurantTableQueryHandler(IMapper mapper, IRestaurantTableRepository restaurantTableRepository, RestaurantTableBusinessRules restaurantTableBusinessRules)
        {
            _mapper = mapper;
            _restaurantTableRepository = restaurantTableRepository;
            _restaurantTableBusinessRules = restaurantTableBusinessRules;
        }

        public async Task<GetByIdRestaurantTableResponse> Handle(GetByIdRestaurantTableQuery request, CancellationToken cancellationToken)
        {
            RestaurantTable? restaurantTable = await _restaurantTableRepository.GetAsync(predicate: rt => rt.Id == request.Id, cancellationToken: cancellationToken);
            await _restaurantTableBusinessRules.RestaurantTableShouldExistWhenSelected(restaurantTable);

            GetByIdRestaurantTableResponse response = _mapper.Map<GetByIdRestaurantTableResponse>(restaurantTable);
            return response;
        }
    }
}