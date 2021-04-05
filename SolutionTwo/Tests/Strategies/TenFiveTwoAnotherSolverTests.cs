using FluentAssertions;
using Lib.Strategies;
using NUnit.Framework;

namespace Tests.Strategies
{
    [TestFixture]
    public class TenFiveTwoAnotherSolverTests
    {
        [TestCase(01)]
        [TestCase(03)]
        [TestCase(06)]
        [TestCase(08)]
        public void Should_Not_Find_Solution_When_Impossible(long money)
        {
            // arrange
            var solver = new TenFiveTwoAnotherSolver();

            // act
            var isFound = solver.TrySolve(money, out var solution);

            // assert
            isFound.Should().BeFalse();
            solution.Should().NotBeNull();
            solution.Currency.Should().BeNull();
        }

        [TestCase(21, 3, 1, 1)]
        [TestCase(33, 4, 1, 2)]
        [TestCase(37, 1, 1, 3)]
        [TestCase(49, 2, 1, 4)]
        public void Should_Find_Solution_When_Possible(
            long money,             
            long expectedTwoCoins,
            long expectedFiveCoins,
            long expectedTenCoins)
        {
            // arrange
            var solver = new TenFiveTwoAnotherSolver();

            // act
            var isFound = solver.TrySolve(money, out var solution);

            // assert
            isFound.Should().BeTrue();
            solution.Should().NotBeNull();
            solution.Currency.Should().NotBeNull();
            solution.Currency.TwoCoins.Should().Be(expectedTwoCoins);
            solution.Currency.FiveCoins.Should().Be(expectedFiveCoins);
            solution.Currency.TenCoins.Should().Be(expectedTenCoins);
        }
    }
}
