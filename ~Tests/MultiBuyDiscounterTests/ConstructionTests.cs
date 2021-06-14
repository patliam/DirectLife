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
    public class ConstructionTests
    {
        [Fact]
        public void StockIdIsNull_ThrowsException()
        {
            Action action = () => new MultiBuyDiscounter(null, 1, 1);
            action.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void StockIdIsEmpty_ThrowsException()
        {
            Action action = () => new MultiBuyDiscounter("", 1, 1);
            action.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void RequiredMultipleIsZero_ThrowsException()
        {
            Action action = () => new MultiBuyDiscounter("id", 0, 1);
            action.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void DiscountIsZero_ThrowsException()
        {
            Action action = () => new MultiBuyDiscounter("", 1, 0);
            action.Should().Throw<ArgumentException>();
        }
    }
}
