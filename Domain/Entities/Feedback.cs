using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
        public int BirdServiceId { get; set; }
        public virtual BirdService BirdService { get; set; } = null!;
    }
}
