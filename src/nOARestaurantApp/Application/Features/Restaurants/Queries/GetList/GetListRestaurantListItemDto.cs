using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Restaurants.Queries.GetList;

public class GetListRestaurantListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string OpeningHours { get; set; }
    public string ClosingHours { get; set; }
    public string Location { get; set; }
    public string? Photo { get; set; }
}