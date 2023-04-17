using System;
using System.Collections.Generic;

namespace WebAppDeleite.Models
{
    public partial class Item
    {
        public Item()
        {
            BillingDetails = new HashSet<BillingDetail>();
            BuyDetails = new HashSet<BuyDetail>();
            Toppings = new HashSet<Topping>();
        }

        public int Iditem { get; set; }
        public string NameItem { get; set; } = null!;
        public string Qr { get; set; } = null!;
        public decimal UnitCost { get; set; }
        public decimal SellPrice { get; set; }
        public string Flavor { get; set; } = null!;

        public virtual ICollection<BillingDetail> BillingDetails { get; set; }
        public virtual ICollection<BuyDetail> BuyDetails { get; set; }
        public virtual ICollection<Topping> Toppings { get; set; }
    }
}
