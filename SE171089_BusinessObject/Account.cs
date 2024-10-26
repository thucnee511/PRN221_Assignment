﻿using System;
using System.Collections.Generic;

namespace SE171089_BusinessObject
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public int? Status { get; set; }

        public virtual Role Role { get; set; } = null!;
    }
}
