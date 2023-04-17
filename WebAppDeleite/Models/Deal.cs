using System;
using System.Collections.Generic;

namespace WebAppDeleite.Models
{
    public partial class Deal
    {
        public int DealsId { get; set; }
        public decimal Descount { get; set; }
        public string Description { get; set; } = null!;
        public bool Status { get; set; }
        public int BuyId { get; set; }

        public virtual Buy Buy { get; set; } = null!;
    }
}
