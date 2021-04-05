using FluentAssertions;
using Lib.Strategies;
using NUnit.Framework;

namespace Tests.Strategies
{
    [TestFixture]
    public class TenTwoSolverTests
    {
        [TestCase(01)]
        [TestCase(03)]
        [TestCase(11)]
        [TestCase(33)]
        [TestCase(59)]
        public void Should_Not_Find_Solution_When_Impossible(long money)
        {
            // arrange
            var solver = new TenTwoSolver();

            // act
            var isFound = solver.TrySolve(money, out var solution);

            // assert
            isFound.Should().BeFalse();
            solution.Should().NotBeNull();
            solution.Currency.Should().BeNull();
        }

        [TestCase(02, 1, 0, 0)]
        [TestCase(08, 4, 0, 0)]
        [TestCase(10, 0, 0, 1)]
        [TestCase(20, 0, 0, 2)]
        [TestCase(22, 1, 0, 2)]
        [TestCase(34, 2, 0, 3)]
        [TestCase(46, 3, 0, 4)]
        [TestCase(58, 4, 0, 5)]
        [TestCase(60, 0, 0, 6)]
        public void Should_Find_Solution_When_Possible(
            long money,             
            long expectedTwoCoins,
            long expectedFiveCoins,
            long expectedTenCoins)
        {
            // arrange
            var solver = new TenTwoSolver();

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
