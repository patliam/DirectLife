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

        public Till()
        {
            _calculators = new List<IOfferCalculator>();
        }

        public Till(List<IOfferCalculator> Calculators)
        {
            _calculators = Calculators;
        }

        public decimal GetBasketCost(IEnumerable<IStockItem> Basket)
        {
            var cost = Basket?.Sum(x => x.Price) ?? 0m;
            var discount = 0m;
            foreach( var calculator in _calculators )
            {
                discount += calculator.CalculateDiscount(Basket);
            }
            //Need some logic here to deal with discounts >= costs etc
            return cost - discount;
        }
    }
}
 