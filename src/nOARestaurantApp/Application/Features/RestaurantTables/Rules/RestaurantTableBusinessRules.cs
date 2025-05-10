using Application.Features.RestaurantTables.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.RestaurantTables.Rules;

public class RestaurantTableBusinessRules : BaseBusinessRules
{
    private readonly IRestaurantTableRepository _restaurantTableRepository;
    private readonly ILocalizationService _localizationService;

    public RestaurantTableBusinessRules(IRestaurantTableRepository restaurantTableRepository, ILocalizationService localizationService)
    {
        _restaurantTableRepository = restaurantTableRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RestaurantTablesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RestaurantTableShouldExistWhenSelected(RestaurantTable? restaurantTable)
    {
        if (restaurantTable == null)
            await throwBusinessException(RestaurantTablesBusinessMessages.RestaurantTableNotExists);
    }

    public async Task RestaurantTableIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RestaurantTable? restaurantTable = await _restaurantTableRepository.GetAsync(
            predicate: rt => rt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RestaurantTableShouldExistWhenSelected(restaurantTable);
    }

    public async Task TableCapacityMustBeGreaterThenZero(int capacity)
    {
        if(capacity < 1)
        {
            throw new BusinessException(RestaurantTablesBusinessMessages.TableCapacityMustBeGreaterThanZero); 
        }
    }

    public async Task TableNumberMustBeUniqueInRestaurant(Guid restaurantId, int tableNumber)
    {
        var existing = await _restaurantTableRepository.GetAsync
            (t => t.RestaurantId == restaurantId && t.TableNumber == tableNumber);

        if (existing != null)
            throw new BusinessException(RestaurantTablesBusinessMessages.TableNumberMustBeUniqueInRestaurant);
    }

    public async Task TableLocationMustBeValid(string location)
    {
        var validLocations = new List<string> { "Ýç Mekan", "Dýþ Mekan", "Balkon", "Bahçe" };

        if (!validLocations.Contains(location))
            throw new BusinessException(RestaurantTablesBusinessMessages.InvalidTableLocation);
    }

    public async Task 
    
}