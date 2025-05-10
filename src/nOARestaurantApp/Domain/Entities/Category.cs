using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Category : Entity<Guid>
{
    public string Name { get; set; }                          // Kategori adı (örnek: Tatlılar)
    public string? Description { get; set; }

    public Guid MenuId { get; set; }                          // Hangi menüye ait
    public Menu Menu { get; set; }

    public ICollection<MenuItem> MenuItems { get; set; }      // Bu kategoriye ait yemekler
}
