using ParcelCalculator.Enums;
using ParcelCalculator.Services;

namespace ParcelCalculatorTests.Services
{
    public class CostServiceUnitTest
    {
        private CostService _sut;
        public CostServiceUnitTest()
        {
            _sut = new CostService();
        }

        [Fact]
        public void GetCost_WhenCategoryIsReject_ShouldReturnNA()
        {

            // Act
            var actual = _sut.GetCost(Category.Reject, 51, 1);

            // Assert
            Assert.Equal("N/A", actual);

        }

        [Fact]
        public void GetCost_WhenCategoryIsHeavy_ShouldReturnRightCost()
        {
            // Arrange
            var weight = 11;
            var expectedCost = (weight * 15).ToString("C");

            // Act
            var actual = _sut.GetCost(Category.Heavy, weight, 1);

            // Assert
            Assert.Equal(expectedCost, actual);

        }

        [Fact]
        public void GetCost_WhenCategorySmall_ShouldReturnRightCost()
        {
            // Arrange
            var volume = 1000m;
            var expectedCost = (volume * 0.05m).ToString("C");

            // Act
            var actual = _sut.GetCost(Category.Small, 1, volume);

            // Assert
            Assert.Equal(expectedCost, actual);

        }

        [Fact]
        public void GetCost_WhenCategoryMedium_ShouldReturnRightCost()
        {
            // Arrange
            var volume = 1600m;
            var expectedCost = (volume * 0.04m).ToString("C");

            // Act
            var actual = _sut.GetCost(Category.Medium, 1, volume);

            // Assert
            Assert.Equal(expectedCost, actual);

        }

        [Fact]
        public void GetCost_WhenCategoryLarge_ShouldReturnRightCost()
        {
            // Arrange
            var volume = 2501m;
            var expectedCost = (volume * 0.03m).ToString("C");

            // Act
            var actual = _sut.GetCost(Category.Large, 1, volume);

            // Assert
            Assert.Equal(expectedCost, actual);

        }
    }
}
