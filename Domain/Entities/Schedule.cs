using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Schedule
    {
        public Schedule()
        {
            ScheduleTickets = new HashSet<ScheduleTicket>();
        }

        public int Id { get; set; }
        public int BirdServiceId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int AvailableSlots { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeleteBy { get; set; }

        public virtual BirdService BirdService { get; set; } = null!;
        public virtual ICollection<ScheduleTicket> ScheduleTickets { get; set; }
    }
}
