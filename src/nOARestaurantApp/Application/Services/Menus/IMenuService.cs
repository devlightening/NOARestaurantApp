using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Menus;

public interface IMenuService
{
    Task<Menu?> GetAsync(
        Expression<Func<Menu, bool>> predicate,
        Func<IQueryable<Menu>, IIncludableQueryable<Menu, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Menu>?> GetListAsync(
        Expression<Func<Menu, bool>>? predicate = null,
        Func<IQueryable<Menu>, IOrderedQueryable<Menu>>? orderBy = null,
        Func<IQueryable<Menu>, IIncludableQueryable<Menu, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Menu> AddAsync(Menu menu);
    Task<Menu> UpdateAsync(Menu menu);
    Task<Menu> DeleteAsync(Menu menu, bool permanent = false);
}
