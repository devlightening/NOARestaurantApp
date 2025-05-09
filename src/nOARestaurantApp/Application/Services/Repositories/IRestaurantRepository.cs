using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRestaurantRepository : IAsyncRepository<Restaurant, Guid>, IRepository<Restaurant, Guid>
{
}