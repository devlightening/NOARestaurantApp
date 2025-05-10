
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class RestaurantTable : Entity<Guid>
{
    public Guid RestaurantId { get; set; }
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public string Location { get; set; }
    public bool IsAvailable { get; set; }
    public Restaurant Restaurant { get; set; }
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

public enum TableLocation
{
    Indoor,     // İç Mekan
    Outdoor,    // Dış Mekan
    Balcony,    // Balkon
    Garden      // Bahçe
}

