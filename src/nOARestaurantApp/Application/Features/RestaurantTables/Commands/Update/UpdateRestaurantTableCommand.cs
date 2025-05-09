using Application.Features.RestaurantTables.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RestaurantTables.Commands.Update;

public class UpdateRestaurantTableCommand : IRequest<UpdatedRestaurantTableResponse>
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public string Location { get; set; }
    public bool IsAvailable { get; set; }

    public class UpdateRestaurantTableCommandHandler : IRequestHandler<UpdateRestaurantTableCommand, UpdatedRestaurantTableResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        private readonly RestaurantTableBusinessRules _restaurantTableBusinessRules;

        public UpdateRestaurantTableCommandHandler(IMapper mapper, IRestaurantTableRepository restaurantTableRepository,
                                         RestaurantTableBusinessRules restaurantTableBusinessRules)
        {
            _mapper = mapper;
            _restaurantTableRepository = restaurantTableRepository;
            _restaurantTableBusinessRules = restaurantTableBusinessRules;
        }

        public async Task<UpdatedRestaurantTableResponse> Handle(UpdateRestaurantTableCommand request, CancellationToken cancellationToken)
        {
            RestaurantTable? restaurantTable = await _restaurantTableRepository.GetAsync(predicate: rt => rt.Id == request.Id, cancellationToken: cancellationToken);
            await _restaurantTableBusinessRules.RestaurantTableShouldExistWhenSelected(restaurantTable);
            restaurantTable = _mapper.Map(request, restaurantTable);

            await _restaurantTableRepository.UpdateAsync(restaurantTable!);

            UpdatedRestaurantTableResponse response = _mapper.Map<UpdatedRestaurantTableResponse>(restaurantTable);
            return response;
        }
    }
}