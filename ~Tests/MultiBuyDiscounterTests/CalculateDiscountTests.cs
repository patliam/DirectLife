using DirectLife;
using DirectLife.BusinessLogic;
using DirectLife.Data;
using DirectLife.Interfaces;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace _Tests.MultiBuyDiscounterTests
{
    public class CalculateDiscountTests
    {
        [Fact]
        public void BasketIsNull_Returns0()
        {
            var discounter = new MultiBuyDiscounter("id",1,1);

            discounter.CalculateDiscount(null).Should().Be(0);
        }

        [Fact]
        public void BasketIsEmpty_Returns0()
        {
            var discounter = new MultiBuyDiscounter("id", 1, 12);
            var basket = new List<StockItem>();

            discounter.CalculateDiscount(basket).Should().Be(0);
        }

        [Fact]
        public void BasketMeetsOffer_ReturnsDiscount()
        {
            var id = "id";
            var cnt = 2;
            var discount = 2.5m;

            var discounter = new MultiBuyDiscounter(id, cnt, discount);
            var basket = new List<StockItem>
            {
                new StockItem( id, 0),
                new StockItem( id, 0),
            };

            discounter.CalculateDiscount(basket).Should().Be(discount);
        }

        [Fact]
        public void BasketMeetsOfferTwice_ReturnsDoubleDiscount()
        {
            var id = "id";
            var cnt = 2;
            var discount = 2.5m;

            var discounter = new MultiBuyDiscounter(id, cnt, discount);
            var basket = new List<StockItem>
            {
                new StockItem( id, 0),
                new StockItem( id, 0),
                new StockItem( id, 0),
                new StockItem( id, 0)
            };

            discounter.CalculateDiscount(basket).Should().Be(discount * 2);
        }

        [Fact]
        public void BasketHasCountButNotType_Returns0()
        {
            var id = "id";
            var cnt = 2;
            var discount = 2.5m;

            var discounter = new MultiBuyDiscounter(id, cnt, discount);
            var basket = new List<StockItem>
            {
                new StockItem( id, 0),
                new StockItem( "other", 0)
            };

            discounter.CalculateDiscount(basket).Should().Be(0);
        }

        [Fact]
        public void BasketHasOfferPlusPartial_ReturnsDiscount()
        {
            var id = "id";
            var cnt = 3;
            var discount = 2.5m;

            var discounter = new MultiBuyDiscounter(id, cnt, discount);
            var basket = new List<StockItem>
            {
                new StockItem( id, 0),
                new StockItem( id, 0),
                new StockItem( id, 0),
                new StockItem( id, 0),
                new StockItem( id, 0)
            };

            discounter.CalculateDiscount(basket).Should().Be(discount);
        }
    }
}
