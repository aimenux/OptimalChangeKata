using System;
using FluentAssertions;
using Lib.Models;
using NUnit.Framework;

namespace Tests.Models
{
    [TestFixture]
    public class CurrencyTests
    {
        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        public void Should_Throw_ArgumentException_For_Invalid_Currency(
            long twoEuroCoins,
            long fiveEuroBanknotes,
            long tenEuroBanknotes)
        {
            // arrange
            // act
            Func<Currency> createCurrency = () => new Currency(twoEuroCoins, fiveEuroBanknotes, tenEuroBanknotes);

            // assert
            createCurrency.Should().Throw<ArgumentException>();
        }

        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 1, 1, 17)]
        [TestCase(2, 2, 2, 34)]
        public void Should_Get_Valid_TotalMoney_For_Currency(
            long twoCoins,
            long fiveCoins,
            long tenCoins,
            long expectedTotalMoney)
        {
            // arrange
            var currency = new Currency(twoCoins, fiveCoins, tenCoins);

            // act
            var totalMoney = currency.TotalMoney;

            // assert
            totalMoney.Should().Be(expectedTotalMoney);
        }

        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 0, 0, 1)]
        [TestCase(2, 1, 0, 3)]
        [TestCase(3, 2, 1, 6)]
        public void Should_Get_Valid_TotalCoins_For_Currency(
            long twoCoins,
            long fiveCoins,
            long tenCoins,
            long expectedTotalCoins)
        {
            // arrange
            var currency = new Currency(twoCoins, fiveCoins, tenCoins);

            // act
            var totalCoins = currency.TotalCoins;

            // assert
            totalCoins.Should().Be(expectedTotalCoins);
        }
    }
}