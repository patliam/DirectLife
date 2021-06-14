using DirectLife;
using DirectLife.Data;
using DirectLife.Infrastructure;
using DirectLife.Interfaces;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace _Tests.TillTests
{
    public class GetBasketCostTests
    {
        [Fact]
        public void BasketIsNull_ThrowsException()
        {
            List<IStockItem> basket = null;
            var till = new Till();

            till.GetBasketCost(basket).Should().Be(0);
        }

        [Fact]
        public void BasketIsEmpty_ReturnsZero()
        {
            var basket = new List<IStockItem>();
            var till = new Till();

            till.GetBasketCost(basket).Should().Be(0);
        }

        [Fact]
        public void BasketContains2Items_ReturnsSumPrice()
        {
            var price1 = 1.2m;
            var price2 = 3.4m;
            var basket = new List<IStockItem>
            {
                new StockItem("", price1 ),
                new StockItem("", price2)
            };
            var till = new Till();
            till.GetBasketCost(basket).Should().Be(price1 + price2);
        }

        [Fact]
        public void BasketMeetsOfferRequirements_DiscountApplied()
        {

        }
    }
}
