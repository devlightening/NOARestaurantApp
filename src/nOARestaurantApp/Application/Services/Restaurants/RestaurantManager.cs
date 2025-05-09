using Application.Features.Restaurants.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Restaurants;

public class RestaurantManager : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly RestaurantBusinessRules _restaurantBusinessRules;

    public RestaurantManager(IRestaurantRepository restaurantRepository, RestaurantBusinessRules restaurantBusinessRules)
    {
        _restaurantRepository = restaurantRepository;
        _restaurantBusinessRules = restaurantBusinessRules;
    }

    public async Task<Restaurant?> GetAsync(
        Expression<Func<Restaurant, bool>> predicate,
        Func<IQueryable<Restaurant>, IIncludableQueryable<Restaurant, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Restaurant? restaurant = await _restaurantRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return restaurant;
    }

    public async Task<IPaginate<Restaurant>?> GetListAsync(
        Expression<Func<Restaurant, bool>>? predicate = null,
        Func<IQueryable<Restaurant>, IOrderedQueryable<Restaurant>>? orderBy = null,
        Func<IQueryable<Restaurant>, IIncludableQueryable<Restaurant, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Restaurant> restaurantList = await _restaurantRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return restaurantList;
    }

    public async Task<Restaurant> AddAsync(Restaurant restaurant)
    {
        Restaurant addedRestaurant = await _restaurantRepository.AddAsync(restaurant);

        return addedRestaurant;
    }

    public async Task<Restaurant> UpdateAsync(Restaurant restaurant)
    {
        Restaurant updatedRestaurant = await _restaurantRepository.UpdateAsync(restaurant);

        return updatedRestaurant;
    }

    public async Task<Restaurant> DeleteAsync(Restaurant restaurant, bool permanent = false)
    {
        Restaurant deletedRestaurant = await _restaurantRepository.DeleteAsync(restaurant);

        return deletedRestaurant;
    }
}
