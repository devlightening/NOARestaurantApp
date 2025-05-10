using Application.Features.RestaurantTables.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RestaurantTables.Commands.Create;

public class CreateRestaurantTableCommand : IRequest<CreatedRestaurantTableResponse>
{
    public Guid RestaurantId { get; set; }
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public string Location { get; set; }
    public bool IsAvailable { get; set; }

    public class CreateRestaurantTableCommandHandler : IRequestHandler<CreateRestaurantTableCommand, CreatedRestaurantTableResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        private readonly RestaurantTableBusinessRules _restaurantTableBusinessRules;

        public CreateRestaurantTableCommandHandler(IMapper mapper, IRestaurantTableRepository restaurantTableRepository,
                                         RestaurantTableBusinessRules restaurantTableBusinessRules)
        {
            _mapper = mapper;
            _restaurantTableRepository = restaurantTableRepository;
            _restaurantTableBusinessRules = restaurantTableBusinessRules;
        }

        public async Task<CreatedRestaurantTableResponse> Handle(CreateRestaurantTableCommand request, CancellationToken cancellationToken)
        {
            _restaurantTableBusinessRules.TableCapacityMustBeGreaterThenZero(request.TableNumber);
            await _restaurantTableBusinessRules.TableNumberMustBeUniqueInRestaurant(request.RestaurantId,request.TableNumber);
            await _restaurantTableBusinessRules.TableLocationMustBeValid(request.Location);


            RestaurantTable restaurantTable = _mapper.Map<RestaurantTable>(request);

            await _restaurantTableRepository.AddAsync(restaurantTable);

            CreatedRestaurantTableResponse response = _mapper.Map<CreatedRestaurantTableResponse>(restaurantTable);
            return response;
            
            
        }
    }
}