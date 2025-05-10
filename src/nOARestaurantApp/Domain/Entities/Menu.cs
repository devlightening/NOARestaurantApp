
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Menu : Entity<Guid>
{
    public string Name { get; set; }                        // Menü adı: "Kahvaltı Menüsü", "Günlük Menü" vb.
    public string? Description { get; set; }                // Açıklama
    public Guid RestaurantId { get; set; }                  // Hangi restorana ait
    public string? Photo { get; set; }                      // Menü kapağı resmi
    public bool IsActive { get; set; } = true;              // Şu an aktif mi?

    public Restaurant Restaurant { get; set; }

    public ICollection<Category> Categories { get; set; }   // Tatlı, içecek vs.
    public ICollection<MenuItem> MenuItems { get; set; }    // Menüdeki ürünler


    // "Menüyü silip ardından narchgen generate crud komutunu çalıştırarak tekrar ekledim. 
    //Entity’lerde OrderItem, Order ve MenuItem gibi yeni özellikler ekledim ve ilişkileri doğru şekilde bağladım.
    //Şu an için, menüye eklenen yeni özellikler için manuel eklemeler yapmam gerekiyor
    //ve entity’lerin doğru şekilde ilişkilerle bağlanmadığı sürece CRUD işlemleri yapmak uygun olmayacaktır."

}

