using System;
using System.Collections.Generic;

namespace WebAppDeleite.Models
{
    public partial class Counter
    {
        public Counter()
        {
            BillingDetails = new HashSet<BillingDetail>();
        }

        public int CounterId { get; set; }
        public decimal WeakCounter { get; set; }
        public decimal MounthCounter { get; set; }
        public decimal YearCounter { get; set; }

        public virtual ICollection<BillingDetail> BillingDetails { get; set; }
    }
}
