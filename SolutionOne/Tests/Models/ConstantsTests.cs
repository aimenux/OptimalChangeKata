using FluentAssertions;
using Lib.Models;
using NUnit.Framework;

namespace Tests.Models
{
    [TestFixture]
    public class ConstantsTests
    {
        [Test]
        public void Should_TwoCoinsValue_Equals_To_Two()
        {
            // arrange
            // act
            // assert
            Constants.TwoCoinValue.Should().Be(2);
        }

        [Test]
        public void Should_FiveCoinsValue_Equals_To_Five()
        {
            // arrange
            // act
            // assert
            Constants.FiveCoinValue.Should().Be(5);
        }
        
        [Test]
        public void Should_TenCoinsValue_Equals_To_Ten()
        {
            // arrange
            // act
            // assert
            Constants.TenCoinValue.Should().Be(10);
        }
    }
}