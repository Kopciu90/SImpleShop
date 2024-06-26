﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShop.Core.Entities
{
    public class UserRole
    {
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
