using NArchitecture.Core.Application.Responses;

namespace Application.Features.Restaurants.Commands.Update;

public class UpdatedRestaurantResponse : IResponse
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