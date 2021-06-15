using DirectLife;
using DirectLife.BusinessLogic;
using DirectLife.Data;
using DirectLife.Interfaces;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;


namespace _Tests
{
    public class IntegrationTests
    {

        [Fact]
        public void TestExample()
        {
            var basket = new List<IStockItem>
            {
                CreateApple(),
                CreateApple(),
                CreateOrange(),
                CreateApple(),
            };

            var till = new Till();

            till.GetBasketCost(basket).Should().Be(2.05m);
        }

        [Fact]
        public void TestOneOfEachOffer()
        {
            var basket = new List<IStockItem>
            {
                CreateApple(),
                CreateApple(),
                CreateApple(),
                CreateOrange(),
                CreateOrange(),
                CreateOrange(),
            };

            var discounters = new List<IOfferCalculator>
            {
                CreateApplesOffer(),
                CreateOrangesOffer()
            };

            var till = new Till(discounters);

            till.GetBasketCost(basket).Should().Be(1.7m);
        }

        private StockItem CreateApple()
        {
            return new StockItem("apple", 0.6m);
        }

        private StockItem CreateOrange()
        {
            return new StockItem("orange", 0.25m);
        }
        private IOfferCalculator CreateApplesOffer()
        {
            return OfferCalculatorFactory.BuyOneGetOneFree(CreateApple());
        }

        private IOfferCalculator CreateOrangesOffer()
        {
            return OfferCalculatorFactory.ThreeForTwo(CreateOrange());
        }
    }
}
