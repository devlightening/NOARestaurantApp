using NArchitecture.Core.Application.Responses;

namespace Application.Features.RestaurantTables.Commands.Create;

public class CreatedRestaurantTableResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public string Location { get; set; }
    public bool IsAvailable { get; set; }
}