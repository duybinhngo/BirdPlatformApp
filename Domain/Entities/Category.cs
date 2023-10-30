using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Category
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int IsActive { get; set; }

        public virtual ICollection<BirdService> BirdService { get; set; } = new List<BirdService>();
    }
}
