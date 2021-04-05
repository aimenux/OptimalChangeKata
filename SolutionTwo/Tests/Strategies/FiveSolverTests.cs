using FluentAssertions;
using Lib.Strategies;
using NUnit.Framework;

namespace Tests.Strategies
{
    [TestFixture]
    public class FiveSolverTests
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

        [TestCase(10, 0, 2, 0)]
        [TestCase(25, 0, 5, 0)]
        [TestCase(40, 0, 8, 0)]
        public void Should_Find_Solution_When_Possible(
            long money,             
            long expectedTwoCoins,
            long expectedFiveCoins,
            long expectedTenCoins)
        {
            // arrange
            var solver = new FiveSolver();

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
