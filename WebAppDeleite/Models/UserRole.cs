﻿using System;
using System.Collections.Generic;

namespace WebAppDeleite.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int UserRoleId { get; set; }
        public string UserRoleDescription { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
