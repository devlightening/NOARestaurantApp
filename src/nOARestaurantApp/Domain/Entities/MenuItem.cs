using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MenuItem : Entity<Guid>
{
    public Guid MenuId { get; set; }
    public Guid CategoryId { get; set; }

    public string Name { get; set; }                        // Ürün adı: "Tavuk Izgara"
    public string? Description { get; set; }
    public string Ingredients { get; set; }                 // Malzemeler: "Tavuk, Baharat, Zeytinyağı"
    public decimal Price { get; set; }
    public string? Photo { get; set; }
    public bool IsAvailable { get; set; } = true;           // Geçici olarak kapalı olabilir

    public Menu Menu { get; set; }
    public Category Category { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}
