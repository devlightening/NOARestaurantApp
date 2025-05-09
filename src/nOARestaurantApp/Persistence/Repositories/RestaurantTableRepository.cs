using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RestaurantTableRepository : EfRepositoryBase<RestaurantTable, Guid, BaseDbContext>, IRestaurantTableRepository
{
    public RestaurantTableRepository(BaseDbContext context) : base(context)
    {
    }
}