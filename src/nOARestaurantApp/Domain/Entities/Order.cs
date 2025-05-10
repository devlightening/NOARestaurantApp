using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Order : Entity<Guid>
{
    public Guid RestaurantId { get; set; }                    // Sipariş hangi restoranda verildi
    public Guid? TableId { get; set; }                        // Masa numarası (varsa)
    public Guid? EmployeeId { get; set; }                     // Siparişi alan personel
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public OrderStatus Status { get; set; } = OrderStatus.Pending; // Enum (Pending, Preparing, Completed, Cancelled)
    public decimal TotalPrice { get; set; }                   // Toplam tutar (otomatik hesaplanmalı)
    public string? Notes { get; set; }                        // İsteğe bağlı notlar
    public Restaurant Restaurant { get; set; }
    public RestaurantTable? Table { get; set; }
    public Employee? Employee { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}
public enum OrderStatus
{
    Pending,    // Sipariş bekliyor
    Preparing,  // Sipariş hazırlanıyor
    Ready,      // Sipariş hazır
    Delivered,  // Sipariş teslim edildi
    Cancelled   // Sipariş iptal edildi
}