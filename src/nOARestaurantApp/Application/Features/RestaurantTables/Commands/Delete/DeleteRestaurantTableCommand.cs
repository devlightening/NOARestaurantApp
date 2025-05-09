using Application.Features.RestaurantTables.Constants;
using Application.Features.RestaurantTables.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RestaurantTables.Commands.Delete;

public class DeleteRestaurantTableCommand : IRequest<DeletedRestaurantTableResponse>
{
    public Guid Id { get; set; }

    public class DeleteRestaurantTableCommandHandler : IRequestHandler<DeleteRestaurantTableCommand, DeletedRestaurantTableResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        private readonly RestaurantTableBusinessRules _restaurantTableBusinessRules;

        public DeleteRestaurantTableCommandHandler(IMapper mapper, IRestaurantTableRepository restaurantTableRepository,
                                         RestaurantTableBusinessRules restaurantTableBusinessRules)
        {
            _mapper = mapper;
            _restaurantTableRepository = restaurantTableRepository;
            _restaurantTableBusinessRules = restaurantTableBusinessRules;
        }

        public async Task<DeletedRestaurantTableResponse> Handle(DeleteRestaurantTableCommand request, CancellationToken cancellationToken)
        {
            RestaurantTable? restaurantTable = await _restaurantTableRepository.GetAsync(predicate: rt => rt.Id == request.Id, cancellationToken: cancellationToken);
            await _restaurantTableBusinessRules.RestaurantTableShouldExistWhenSelected(restaurantTable);

            await _restaurantTableRepository.DeleteAsync(restaurantTable!);

            DeletedRestaurantTableResponse response = _mapper.Map<DeletedRestaurantTableResponse>(restaurantTable);
            return response;
        }
    }
}