using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MenuRepository : EfRepositoryBase<Menu, Guid, BaseDbContext>, IMenuRepository
{
    public MenuRepository(BaseDbContext context) : base(context)
    {
    }
}