using FluentAssertions;
using Lib.Strategies;
using NUnit.Framework;

namespace Tests.Strategies
{
    [TestFixture]
    public class TenFiveTwoSolverTests
    {
        [TestCase(01)]
        [TestCase(03)]
        [TestCase(11)]
        [TestCase(33)]
        public void Should_Not_Find_Solution_When_Impossible(long money)
        {
            // arrange
            var solver = new TenFiveTwoSolver();

            // act
            var isFound = solver.TrySolve(money, out var solution);

            // assert
            isFound.Should().BeFalse();
            solution.Should().NotBeNull();
            solution.Currency.Should().BeNull();
        }

        [TestCase(20, 0, 0, 2)]
        [TestCase(24, 2, 0, 2)]
        [TestCase(37, 1, 1, 3)]
        [TestCase(49, 2, 1, 4)]
        [TestCase(50, 0, 0, 5)]
        public void Should_Find_Solution_When_Possible(
            long money,             
            long expectedTwoCoins,
            long expectedFiveCoins,
            long expectedTenCoins)
        {
            // arrange
            var solver = new TenFiveTwoSolver();

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
