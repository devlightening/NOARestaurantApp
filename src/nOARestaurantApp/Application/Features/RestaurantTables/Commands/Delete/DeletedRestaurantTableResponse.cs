using NArchitecture.Core.Application.Responses;

namespace Application.Features.RestaurantTables.Commands.Delete;

public class DeletedRestaurantTableResponse : IResponse
{
    public Guid Id { get; set; }
}