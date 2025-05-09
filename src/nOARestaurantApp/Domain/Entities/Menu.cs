
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Menu : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Photo { get; set; }
    public Guid RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
}
