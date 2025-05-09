using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RestaurantTables;

public interface IRestaurantTableService
{
    Task<RestaurantTable?> GetAsync(
        Expression<Func<RestaurantTable, bool>> predicate,
        Func<IQueryable<RestaurantTable>, IIncludableQueryable<RestaurantTable, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RestaurantTable>?> GetListAsync(
        Expression<Func<RestaurantTable, bool>>? predicate = null,
        Func<IQueryable<RestaurantTable>, IOrderedQueryable<RestaurantTable>>? orderBy = null,
        Func<IQueryable<RestaurantTable>, IIncludableQueryable<RestaurantTable, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RestaurantTable> AddAsync(RestaurantTable restaurantTable);
    Task<RestaurantTable> UpdateAsync(RestaurantTable restaurantTable);
    Task<RestaurantTable> DeleteAsync(RestaurantTable restaurantTable, bool permanent = false);
}
