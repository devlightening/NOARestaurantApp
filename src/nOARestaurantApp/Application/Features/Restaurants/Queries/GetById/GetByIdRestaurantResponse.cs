using NArchitecture.Core.Application.Responses;

namespace Application.Features.Restaurants.Queries.GetById;

public class GetByIdRestaurantResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public TimeSpan OpeningHours { get; set; }
    public TimeSpan ClosingHours { get; set; }
    public string Location { get; set; }
    public string? Photo { get; set; }
}