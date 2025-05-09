using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RestaurantRepository : EfRepositoryBase<Restaurant, Guid, BaseDbContext>, IRestaurantRepository
{
    public RestaurantRepository(BaseDbContext context) : base(context)
    {
    }
}