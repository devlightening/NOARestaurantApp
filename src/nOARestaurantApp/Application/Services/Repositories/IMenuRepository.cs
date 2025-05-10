using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMenuRepository : IAsyncRepository<Menu, Guid>, IRepository<Menu, Guid>
{
}