using System;
using System.Collections.Generic;

namespace WebAppDeleite.Models
{
    public partial class Buy
    {
        public Buy()
        {
            BuyDetails = new HashSet<BuyDetail>();
            Deals = new HashSet<Deal>();
        }

        public int BuyId { get; set; }
        public DateTime BuyDate { get; set; }
        public int BuyNumber { get; set; }
        public byte[]? BuyNotes { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<BuyDetail> BuyDetails { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
    }
}
