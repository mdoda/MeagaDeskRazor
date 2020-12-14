using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazor
{
    public class Delivery
    {
        public int DeliveryId { get; set; }//PK

        public string DeliveryName { get; set; }
        public decimal PriceLessThan1000 { get; set; }
        public decimal PriceBetween1000And2000 { get; set; }
        public decimal PriceOver2000 { get; set; }
    }
}
