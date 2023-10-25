using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class BIrdServiceModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } 
        public decimal ProductPrice { get; set; }
        public string? Description { get; set; }
        public int IsActive { get; set; }
        public int TypeId { get; set; }
        public int ProviderId { get; set; }
    }
}
