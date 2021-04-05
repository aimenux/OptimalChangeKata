using FluentAssertions;
using Lib.Strategies;
using NUnit.Framework;

namespace Tests.Strategies
{
    [TestFixture]
    public class TenSolverTests
    {
        [TestCase(01)]
        [TestCase(03)]
        [TestCase(11)]
        [TestCase(33)]
        [TestCase(59)]
        public void Should_Not_Find_Solution_When_Impossible(long money)
        {
            // arrange
            var solver = new TenSolver();

            // act
            var isFound = solver.TrySolve(money, out var solution);

            // assert
            isFound.Should().BeFalse();
            solution.Should().NotBeNull();
            solution.Currency.Should().BeNull();
        }

        [TestCase(10, 0, 0, 1)]
        [TestCase(30, 0, 0, 3)]
        [TestCase(50, 0, 0, 5)]
        public void Should_Find_Solution_When_Possible(
            long money,             
            long expectedTwoEuroCoins,
            long expectedFiveEuroBanknotes,
            long expectedTenEuroBanknotes)
        {
            // arrange
            var solver = new TenSolver();

            // act
            var isFound = solver.TrySolve(money, out var solution);

            // assert
            isFound.Should().BeTrue();
            solution.Should().NotBeNull();
            solution.Currency.Should().NotBeNull();
            solution.Currency.TwoCoins.Should().Be(expectedTwoEuroCoins);
            solution.Currency.FiveCoins.Should().Be(expectedFiveEuroBanknotes);
            solution.Currency.TenCoins.Should().Be(expectedTenEuroBanknotes);
        }
    }
}
