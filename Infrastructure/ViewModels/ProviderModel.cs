using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class ProviderModel
    {
        public int Id { get; set; }
        public string ProviderName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public int RoleId { get; set; }
        public string? AvatarUrl { get; set; }
        public int IsActive { get; set; }
    }
}
