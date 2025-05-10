using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class OrderItem : Entity<Guid>
{
    public Guid OrderId { get; set; }
    public Guid MenuItemId { get; set; }

    public int Quantity { get; set; }                        // Kaç adet
    public decimal UnitPrice { get; set; }                   // Sipariş anındaki fiyat
    public string? SpecialInstructions { get; set; }         // Örneğin: "Acısız olsun"

    public Order Order { get; set; }
    public MenuItem MenuItem { get; set; }
    public int CustomerIndex { get; set; }


}
