using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Payment : Entity<Guid>
{
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public DateTime PaymentDate { get; set; }
    public Order Order { get; set; }

}
public enum PaymentType { Cash, CreditCard, Online }
public enum PaymentStatus { Pending, Completed, Failed }
