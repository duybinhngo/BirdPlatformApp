using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class BirdService
    {
        public BirdService()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public string? Description { get; set; }
        public int IsActive { get; set; }
        public int TypeId { get; set; }
        public int ProviderId { get; set; }

        public virtual Provider Provider { get; set; } = null!;
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
