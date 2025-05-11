
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Employee : Entity<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public EmployeePosition Position { get; set; }
    public Guid RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = default!;
    public DateTime  BirthDate { get; set; }



}

public enum EmployeePosition
{
    Manager,
    Waiter,
    Chef,
    Cleaner,
    Cashier
}
