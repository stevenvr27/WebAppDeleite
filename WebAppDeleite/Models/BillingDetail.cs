using System;
using System.Collections.Generic;

namespace WebAppDeleite.Models
{
    public partial class BillingDetail
    {
        public int BillingBillingId { get; set; }
        public int ItemIditem { get; set; }
        public decimal Pirice { get; set; }
        public int CounterId { get; set; }

        public virtual Billing BillingBilling { get; set; } = null!;
        public virtual Counter Counter { get; set; } = null!;
        public virtual Item ItemIditemNavigation { get; set; } = null!;
    }
}
