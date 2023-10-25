using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public int? RoleId { get; set; }
        public int? IsActive { get; set; }
        public string? Email {  get; set; }
        public string? Username { get; set; }
        public string? AvatarUrl { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
