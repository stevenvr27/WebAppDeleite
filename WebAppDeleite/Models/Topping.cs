using System;
using System.Collections.Generic;

namespace WebAppDeleite.Models
{
    public partial class Topping
    {
        public int ToppingId { get; set; }
        public string ToppingName { get; set; } = null!;
        public decimal UnitPriceTopping { get; set; }
        public int Stock { get; set; }
        public int Iditem { get; set; }
        public string Flavor { get; set; } = null!;

        public virtual Item IditemNavigation { get; set; } = null!;
    }
}
