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
        public static class Messages
        {
            public const string BasketIsNull = "BasketIsNull";
        }

        public decimal GetBasketCost(List<IStockItem> Basket)
        {
            if (Basket is null)
            {
                throw new TillException(Messages.BasketIsNull);
            }
            return Basket.Sum(x => x.Price);
        }
    }
}
 