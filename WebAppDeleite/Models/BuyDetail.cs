using System;
using System.Collections.Generic;

namespace WebAppDeleite.Models
{
    public partial class BuyDetail
    {
        public int BuyBuyId { get; set; }
        public int ItemIditem { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitaryPrice { get; set; }
        public decimal Total { get; set; }

        public virtual Buy BuyBuy { get; set; } = null!;
        public virtual Item ItemIditemNavigation { get; set; } = null!;
    }
}
