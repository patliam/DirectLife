using DirectLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectLife.Data
{
    public class StockItem : IStockItem
    {
        public StockItem(string Name, decimal Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
        public decimal Price { get; private set; }

        public string Name { get; private set; }
    }
}
