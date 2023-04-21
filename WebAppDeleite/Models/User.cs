using System;
using System.Collections.Generic;

namespace WebAppDeleite.Models
{
    public partial class User
    {
        public User()
        {
            Billings = new HashSet<Billing>();
            Buys = new HashSet<Buy>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CardId { get; set; } = null!;
        public string LoginPassword { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int UserRoleId { get; set; }
        public int UserStatusId { get; set; }

        public virtual UserRole? UserRole { get; set; } = null!;
        public virtual UserStatus? UserStatus { get; set; } = null!;
        public virtual ICollection<Billing> Billings { get; set; } 
       public virtual ICollection<Buy> Buys { get; set; } 
    }
}
