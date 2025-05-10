using Application.Features.Menus.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Menus.Rules;

public class MenuBusinessRules : BaseBusinessRules
{
    private readonly IMenuRepository _menuRepository;
    private readonly ILocalizationService _localizationService;

    public MenuBusinessRules(IMenuRepository menuRepository, ILocalizationService localizationService)
    {
        _menuRepository = menuRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MenusBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MenuShouldExistWhenSelected(Menu? menu)
    {
        if (menu == null)
            await throwBusinessException(MenusBusinessMessages.MenuNotExists);
    }

    public async Task MenuIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Menu? menu = await _menuRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MenuShouldExistWhenSelected(menu);
    }
}