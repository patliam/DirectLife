using DirectLife.BusinessLogic;
using DirectLife.Data;
using DirectLife.Interfaces;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace _Tests.TillTests
{
    public class GetBasketCostTests
    {
        [Fact]
        public void BasketIsNull_Returns0()
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
        public void BasketMeets2OfferRequirements_2DiscountsApplied()
        {
            var discount1 = 12.8m;
            var offer1 = Substitute.For<IOfferCalculator>();
            offer1.CalculateDiscount(Arg.Any<List<IStockItem>>()).Returns(discount1);
            var discount2 = 2.5m;
            var offer2 = Substitute.For<IOfferCalculator>();
            offer2.CalculateDiscount(Arg.Any<List<IStockItem>>()).Returns(discount2);
            var price1 = discount1 * 3;
            var price2 = discount2 * 2;
            var basket = new List<IStockItem>
            {
                new StockItem("", price1 ),
                new StockItem("", price2)
            };
            var till = new Till(new List<IOfferCalculator> { offer1, offer2 } );
            till.GetBasketCost(basket).Should().Be(price1 + price2 - discount1 - discount2);
        }
    }
}
