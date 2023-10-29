using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class ScheduleTicket
    {
        public int Id { get; set; }
        public int BirdServiceId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? PaymentOnline { get; set; }
        public int Status { get; set; }
        public string Description { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public int OrderId { get; set; }
        public DateTime ScheduleFrom { get; set; }
        public DateTime ScheduleTo { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual BirdService BirdService { get; set; } = null!;
    }
}
