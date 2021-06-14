using DirectLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectLife.BusinessLogic
{
    public class MultiBuyDiscounter : IOfferCalculator
    {
        private string _stockIdentifier;
        private int _requiredMultiple;
        private decimal _discount;

        public MultiBuyDiscounter(string StockIdentifier, int RequiredMultiple, decimal Discount)
        {
            if(String.IsNullOrEmpty(StockIdentifier))
            {
                //Argument null exception would be more accurate when it is null, but added complication isn't worth the improved error (imo)
                throw new ArgumentException("Discounts need a stock id");
            }
            if(RequiredMultiple == 0)
            {
                throw new ArgumentException("Required multiple cannot be 0");
            }
            if (Discount == 0)
            {
                throw new ArgumentException("Discount cannot be 0");
            }

            _stockIdentifier = StockIdentifier;
            _requiredMultiple = RequiredMultiple;
            _discount = Discount;
        }

        public decimal CalculateDiscount(IEnumerable<IStockItem> Basket)
        {
            if( Basket == null )
            {
                return 0;
            }

            var cntItems = Basket.Count(x => x.Name == _stockIdentifier);
            var discountMultiple = cntItems / _requiredMultiple;//.net division rounds down
            return discountMultiple * _discount;
        }
    }
}
