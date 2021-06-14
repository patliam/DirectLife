using DirectLife.Infrastructure;
using DirectLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectLife
{
    public class Till
    {
        private List<IOfferCalculator> _calculators;
        public static class Messages
        {
            public const string BasketIsNull = "BasketIsNull";
        }

        //public Till( List<IOfferCalculator> Calculators)
        //{
        //    _calculators = Calculators;
        //}

        public decimal GetBasketCost(List<IStockItem> Basket)
        {
            return Basket?.Sum(x => x.Price) ?? 0;
        }
    }
}
 