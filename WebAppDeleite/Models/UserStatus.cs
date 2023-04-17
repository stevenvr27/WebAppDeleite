using System;
using System.Collections.Generic;

namespace WebAppDeleite.Models
{
    public partial class UserStatus
    {
        public UserStatus()
        {
            Users = new HashSet<User>();
        }

        public int UserStatusId { get; set; }
        public string UserStatusDescription { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
