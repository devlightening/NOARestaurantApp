using Application.Features.Menus.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Menus;

public class MenuManager : IMenuService
{
    private readonly IMenuRepository _menuRepository;
    private readonly MenuBusinessRules _menuBusinessRules;

    public MenuManager(IMenuRepository menuRepository, MenuBusinessRules menuBusinessRules)
    {
        _menuRepository = menuRepository;
        _menuBusinessRules = menuBusinessRules;
    }

    public async Task<Menu?> GetAsync(
        Expression<Func<Menu, bool>> predicate,
        Func<IQueryable<Menu>, IIncludableQueryable<Menu, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Menu? menu = await _menuRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return menu;
    }

    public async Task<IPaginate<Menu>?> GetListAsync(
        Expression<Func<Menu, bool>>? predicate = null,
        Func<IQueryable<Menu>, IOrderedQueryable<Menu>>? orderBy = null,
        Func<IQueryable<Menu>, IIncludableQueryable<Menu, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Menu> menuList = await _menuRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return menuList;
    }

    public async Task<Menu> AddAsync(Menu menu)
    {
        Menu addedMenu = await _menuRepository.AddAsync(menu);

        return addedMenu;
    }

    public async Task<Menu> UpdateAsync(Menu menu)
    {
        Menu updatedMenu = await _menuRepository.UpdateAsync(menu);

        return updatedMenu;
    }

    public async Task<Menu> DeleteAsync(Menu menu, bool permanent = false)
    {
        Menu deletedMenu = await _menuRepository.DeleteAsync(menu);

        return deletedMenu;
    }
}
