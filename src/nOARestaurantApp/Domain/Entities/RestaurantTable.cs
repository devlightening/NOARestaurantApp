
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class RestaurantTable : Entity<Guid>
{
    public Guid RestaurantId { get; set; }
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public string Location { get; set; }
    public bool IsAvailable { get; set; }
}
