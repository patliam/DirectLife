using DirectLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectLife.BusinessLogic
{
    public static class OfferCalculatorFactory
    {
        public static IOfferCalculator BuyOneGetOneFree(IStockItem Stock)
        {
            return new MultiBuyDiscounter(Stock.Name, 2, Stock.Price);
        }
        public static IOfferCalculator ThreeForTwo(IStockItem Stock)
        {
            return new MultiBuyDiscounter(Stock.Name, 3, Stock.Price);
        }
    }
}
