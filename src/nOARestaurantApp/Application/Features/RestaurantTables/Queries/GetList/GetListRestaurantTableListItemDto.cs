using NArchitecture.Core.Application.Dtos;

namespace Application.Features.RestaurantTables.Queries.GetList;

public class GetListRestaurantTableListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public string Location { get; set; }
    public bool IsAvailable { get; set; }
}