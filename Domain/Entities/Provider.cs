﻿using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Provider
    {
        public int Id { get; set; }
        public string ProviderName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string? AvatarUrl { get; set; }
        public int RoleId { get; set; }
        public int IsActive { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<BirdService> BirdServices { get; set; } = new List<BirdService>();

    }
}
