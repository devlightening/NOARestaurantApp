using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Menus.Queries.GetList;

public class GetListMenuListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Photo { get; set; }
    public Guid RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
}