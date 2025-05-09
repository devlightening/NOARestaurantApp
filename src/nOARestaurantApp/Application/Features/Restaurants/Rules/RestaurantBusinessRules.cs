using Application.Features.Restaurants.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Restaurants.Rules;

public class RestaurantBusinessRules : BaseBusinessRules
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly ILocalizationService _localizationService;

    public RestaurantBusinessRules(IRestaurantRepository restaurantRepository, ILocalizationService localizationService)
    {
        _restaurantRepository = restaurantRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RestaurantsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RestaurantShouldExistWhenSelected(Restaurant? restaurant)
    {
        if (restaurant == null)
            await throwBusinessException(RestaurantsBusinessMessages.RestaurantNotExists);
    }

    public async Task RestaurantIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Restaurant? restaurant = await _restaurantRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RestaurantShouldExistWhenSelected(restaurant);
    }

    public async Task PhoneNumberCannotBeDuplicatedWhenInserted(string phoneNumber)
    {
        var existing = await _restaurantRepository.GetAsync(r => r.PhoneNumber == phoneNumber);
        if (existing != null)
           throw new BusinessException(RestaurantsBusinessMessages.DuplicatePhoneNumber);
    }

    public async Task RestaurantNameCannotBeDuplicatedInSameLocation(string name , string location)
    {
        var existing = await _restaurantRepository.GetAsync
            (r => r.Name.ToLower() == name.ToLower() && r.Location.ToLower() == location.ToLower());
        if (existing != null)
            throw new BusinessException(RestaurantsBusinessMessages.DuplicateRestaurantInSameLocation);
    }


    public async Task LocationCannotBeEmpty(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
            throw new BusinessException(RestaurantsBusinessMessages.LocationCannotBeEmpty);
    }

}