using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Order
    {
        public Order()
        {
            ScheduleTickets = new HashSet<ScheduleTicket>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? PaymentOnline { get; set; }
        public int Status { get; set; }
        public string Description { get; set; } = null!;
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<ScheduleTicket> ScheduleTickets { get; set; }
    }
}
