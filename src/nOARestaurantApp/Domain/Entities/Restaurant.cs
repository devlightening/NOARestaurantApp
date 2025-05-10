
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Restaurant : Entity<Guid>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string OpeningHours { get; set; }  // örn: "08:00"
    public string ClosingHours { get; set; }  // örn: "22:00"
    public string Location { get; set; }
    public string? Photo { get; set; }
    public ICollection<Menu> Menus { get; set; }
    public ICollection<RestaurantTable> RestaurantTables { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<Order> Orders { get; set; } // Restoranın aldığı siparişler
    public ICollection<Payment> Payments { get; set; } // Restoranın aldığı ödemeler
    public ICollection<Reservation> Reservations { get; set; } // Restoranın aldığı rezervasyonlar


}
