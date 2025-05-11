using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Reservation : Entity<Guid>
{
    public Guid RestaurantId { get; set; }
    public Guid? TableId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public int PeopleCount { get; set; }
    public DateTime ReservationTime { get; set; }
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    public Restaurant Restaurant { get; set; }
    public RestaurantTable? Table { get; set; }
}
public enum ReservationStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Completed
}