using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MegaDeskRazor.Data;

namespace MegaDeskRazor
{

    public class DeskQuote
    {
        //200 is the starting amount for a desk
        private const decimal BASE_PRICE = 200.00M;

        //Basic Costs
        private const decimal SURFACE_AREA_COST = 1.00M;
        private const decimal DRAWER_COST = 50.00M;
        public int DeskQuoteId { get; set; }//PK

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Quote Price")]
        public decimal QuotePrice { get; set; }

        public int DeskId { get; set; }//FK

        //Navigation property
        public Desk Desk { get; set; }

        [Display(Name = "Delivery")]
        public int DeliveryId { get; set; }
        //Navigation property
        public Delivery Delivery { get; set; }

        public decimal GetQuotePrice(MegaDeskRazorContext context)
        {
            var surfaceArea = this.Desk.Depth * this.Desk.Width;
            decimal quotePrice = BASE_PRICE;
      
            decimal surfacePrice = 0.00M;

            if(surfaceArea > 1000)
            {
                surfacePrice = surfaceArea * SURFACE_AREA_COST;
            }

            decimal drawerPrice = this.Desk.NumberOfDrawers * DRAWER_COST;

            decimal surfaceMaterialPrice = 0.00M;

            var surfaceMaterialPrices = context.DesktopMaterial.
                Where(d => d.DesktopMaterialId == this.Desk.DesktopMaterialId).FirstOrDefault();

            surfaceMaterialPrice = surfaceMaterialPrices.MaterialPrice;

            //quotePrice = context.Desk.DesktopMaterial.MaterialPrice ;

            var shippingPrice = 0.00M;

            var shippingPrices = context.Delivery.Where(sh => sh.DeliveryId == this.Delivery.DeliveryId).FirstOrDefault();


            if (surfaceArea < 1000)
            {
                shippingPrice = shippingPrices.PriceLessThan1000;
            }
            else if (surfaceArea <= 2000)
            {
                shippingPrice = shippingPrices.PriceBetween1000And2000;
            }
            else
            {
                shippingPrice = shippingPrices.PriceOver2000;
            }

            quotePrice = quotePrice + surfacePrice + drawerPrice + surfaceMaterialPrice + shippingPrice;


            return quotePrice;
        }
        ////{
        //    var surfaceArea = this.Desk.Depth * this.Desk.Depth;
        //    decimal quotePrice = BASE_PRICE;
        //    var shippingPrice = 0;
        //    decimal surfacePrice = 0;

        //    if (surfaceArea > 1000)
        //    {
        //        surfacePrice = surfaceArea * SURFACE_AREA_COST;
        //    }

        //    decimal drawerPrice = this.Desk.Drawers * DRAWER_COST;

        //    decimal surfaceMaterialPrice = 0;

        //    switch (this.Desk.DesktopMaterial)
        //    {
        //        case DesktopMaterial.Laminate:
        //            surfaceMaterialPrice = LAMINATE_COST;
        //            break;
        //        case DesktopMaterial.Oak:
        //            surfaceMaterialPrice = OAK_COST;
        //            break;
        //        case DesktopMaterial.Pine:
        //            surfaceMaterialPrice = PINE_COST;
        //            break;
        //        case DesktopMaterial.Rosewood:
        //            surfaceMaterialPrice = ROSEWOOD_COST;
        //            break;
        //        case DesktopMaterial.Veneer:
        //            surfaceMaterialPrice = VENEER_COST;
        //            break;

        //    }
        //    getRushOrderPrices();

        //    switch (this.Shipping)
        //    {
        //        case Delivery.Rush3Days:
        //            if (surfaceArea < 1000)
        //            {
        //                shippingPrice = _rushOrderPrices[0, 0];
        //            }
        //            else if (surfaceArea <= 1000)
        //            {
        //                shippingPrice = _rushOrderPrices[0, 1];
        //            }
        //            else
        //            {
        //                shippingPrice = _rushOrderPrices[0, 2];
        //            }
        //            break;

                //case Delivery.Rush5Days:
                //    if (surfaceArea < 1000)
                //    {
                //        shippingPrice = _rushOrderPrices[1, 0];
                //    }
                //    else if (surfaceArea <= 2000)
                //    {
                //        shippingPrice = _rushOrderPrices[1, 1];
                //    }
                //    else
                //    {
                //        shippingPrice = _rushOrderPrices[1, 2];
                //    }
                //    break;

                //case Delivery.Rush7Days:
                //    if (surfaceArea < 1000)
                //    {
                //        shippingPrice = _rushOrderPrices[2, 0];
                //    }
                //    else if (surfaceArea <= 2000)
                //    {
                //        shippingPrice = _rushOrderPrices[2, 1];
                //    }
                //    else
                //    {
                //        shippingPrice = _rushOrderPrices[2, 2];
                //    }
                //    break;

                    

                    
    //        }
    //        quotePrice = quotePrice + surfacePrice + drawerPrice + surfaceMaterialPrice + shippingPrice;

    //        return quotePrice;
    //    }
    //    private void getRushOrderPrices()
    //    {
    //        _rushOrderPrices = new int[3, 3];
    //        var pricesFile = @"_rushOrderPrices.txt";

    //        string[] prices = File.ReadAllLines(pricesFile);
    //        int i = 0, j = 0;

    //        foreach (string price in prices)
    //        {
    //            _rushOrderPrices[i, j] = int.Parse(price);

    //            if (j == 2)
    //            {
    //                i++;
    //                j = 0;
    //            }
    //            else
    //            {
    //                j++;
    //            }
    //        }
    //    }
    }
}
