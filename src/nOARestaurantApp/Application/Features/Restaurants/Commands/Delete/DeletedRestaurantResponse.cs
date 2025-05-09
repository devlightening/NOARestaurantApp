using NArchitecture.Core.Application.Responses;

namespace Application.Features.Restaurants.Commands.Delete;

public class DeletedRestaurantResponse : IResponse
{
    public Guid Id { get; set; }
}