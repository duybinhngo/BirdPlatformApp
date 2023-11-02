using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class BirdService
    {

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProviderId { get; set; }
        public int AvailableSlots { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeleteBy { get; set; }
        public int IsRentingService { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Provider Provider { get; set; } = null!;
        public virtual ICollection<ScheduleTicket> ScheduleTickets { get; set; } = new List<ScheduleTicket>();
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
