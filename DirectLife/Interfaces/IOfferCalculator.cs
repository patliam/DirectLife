using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectLife.Interfaces
{
    public interface IOfferCalculator
    {
        decimal CalculateDiscount(IEnumerable<IStockItem> Basket);
    }
}
