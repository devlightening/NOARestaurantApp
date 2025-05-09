using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRestaurantTableRepository : IAsyncRepository<RestaurantTable, Guid>, IRepository<RestaurantTable, Guid>
{
}