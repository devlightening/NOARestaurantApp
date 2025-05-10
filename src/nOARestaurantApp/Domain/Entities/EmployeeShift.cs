using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class EmployeeShift: Entity<Guid>
{
    public Guid EmployeeId { get; set; } // Çalışanın ID'si
    public Guid RestaurantId { get; set; } // Restoranın ID'si
    public DateTime ShiftStart { get; set; } // Vardiya başlangıç tarihi ve saati
    public DateTime ShiftEnd { get; set; } // Vardiya bitiş tarihi ve saati
    public string ShiftType { get; set; } // Vardiya türü (örneğin: "Sabah", "Akşam")
    public bool IsActive { get; set; } = true; // Vardiyanın aktif olup olmadığı
    public Employee Employee { get; set; } // İlişkili çalışan
    public Restaurant Restaurant { get; set; } // İlişkili restoran
}
