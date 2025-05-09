using Application.Features.RestaurantTables.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RestaurantTables;

public class RestaurantTableManager : IRestaurantTableService
{
    private readonly IRestaurantTableRepository _restaurantTableRepository;
    private readonly RestaurantTableBusinessRules _restaurantTableBusinessRules;

    public RestaurantTableManager(IRestaurantTableRepository restaurantTableRepository, RestaurantTableBusinessRules restaurantTableBusinessRules)
    {
        _restaurantTableRepository = restaurantTableRepository;
        _restaurantTableBusinessRules = restaurantTableBusinessRules;
    }

    public async Task<RestaurantTable?> GetAsync(
        Expression<Func<RestaurantTable, bool>> predicate,
        Func<IQueryable<RestaurantTable>, IIncludableQueryable<RestaurantTable, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RestaurantTable? restaurantTable = await _restaurantTableRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return restaurantTable;
    }

    public async Task<IPaginate<RestaurantTable>?> GetListAsync(
        Expression<Func<RestaurantTable, bool>>? predicate = null,
        Func<IQueryable<RestaurantTable>, IOrderedQueryable<RestaurantTable>>? orderBy = null,
        Func<IQueryable<RestaurantTable>, IIncludableQueryable<RestaurantTable, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RestaurantTable> restaurantTableList = await _restaurantTableRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return restaurantTableList;
    }

    public async Task<RestaurantTable> AddAsync(RestaurantTable restaurantTable)
    {
        RestaurantTable addedRestaurantTable = await _restaurantTableRepository.AddAsync(restaurantTable);

        return addedRestaurantTable;
    }

    public async Task<RestaurantTable> UpdateAsync(RestaurantTable restaurantTable)
    {
        RestaurantTable updatedRestaurantTable = await _restaurantTableRepository.UpdateAsync(restaurantTable);

        return updatedRestaurantTable;
    }

    public async Task<RestaurantTable> DeleteAsync(RestaurantTable restaurantTable, bool permanent = false)
    {
        RestaurantTable deletedRestaurantTable = await _restaurantTableRepository.DeleteAsync(restaurantTable);

        return deletedRestaurantTable;
    }
}
