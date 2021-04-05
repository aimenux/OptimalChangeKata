using System;
using FluentAssertions;
using Lib.Models;
using Lib.Services;
using NUnit.Framework;

namespace Tests.Services
{
    [TestFixture]
    public class MoneyBoxTests
    {
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Should_Throw_ArgumentException_For_Money_Is_Negative_Or_Zero(long money)
        {
            // arrange
            var service = new MoneyBoxService();

            // act
            Func<Currency> computeCurrency = () => service.ComputeOptimalCurrency(money);

            // assert
            computeCurrency.Should().Throw<ArgumentException>();
        }

        [TestCase(1)]
        [TestCase(3)]
        public void Should_Get_Null_When_Compute_Optimal_Currency_Is_Impossible(long money)
        {
            // arrange
            var service = new MoneyBoxService();

            // act
            var currency = service.ComputeOptimalCurrency(money);

            // assert
            currency.Should().BeNull();
        }

        [TestCase(02, 1, 0, 0)]
        [TestCase(04, 2, 0, 0)]
        [TestCase(05, 0, 1, 0)]
        [TestCase(06, 3, 0, 0)]
        [TestCase(07, 1, 1, 0)]
        [TestCase(08, 4, 0, 0)]
        [TestCase(09, 2, 1, 0)]
        [TestCase(10, 0, 0, 1)]
        [TestCase(11, 3, 1, 0)]
        [TestCase(12, 1, 0, 1)]
        [TestCase(13, 4, 1, 0)]
        [TestCase(14, 2, 0, 1)]
        [TestCase(15, 0, 1, 1)]
        [TestCase(16, 3, 0, 1)]
        [TestCase(17, 1, 1, 1)]
        [TestCase(18, 4, 0, 1)]
        [TestCase(19, 2, 1, 1)]
        [TestCase(20, 0, 0, 2)]
        [TestCase(21, 3, 1, 1)]
        [TestCase(22, 1, 0, 2)]
        [TestCase(23, 4, 1, 1)]
        [TestCase(24, 2, 0, 2)]
        [TestCase(25, 0, 1, 2)]
        public void Should_Compute_Optimal_Currency_When_Is_Possible(
            long money,
            long expectedTwoCoins,
            long expectedFiveCoins,
            long expectedTenCoins)
        {
            // arrange
            var service = new MoneyBoxService();

            // act
            var currency = service.ComputeOptimalCurrency(money);

            // assert
            currency.Should().NotBeNull();
            currency.TotalMoney.Should().Be(money);
            currency.TwoCoins.Should().Be(expectedTwoCoins);
            currency.FiveCoins.Should().Be(expectedFiveCoins);
            currency.TenCoins.Should().Be(expectedTenCoins);
        }
    }
}