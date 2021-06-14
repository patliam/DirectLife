using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectLife.Interfaces
{
    public interface IStockItem
    {
        public decimal Price { get; }
        public string Name { get; }
    }
}
