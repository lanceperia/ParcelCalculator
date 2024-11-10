using ParcelCalculator.Enums;
using ParcelCalculator.Services;

namespace ParcelCalculatorTests.Services
{
    public class CategoryServiceUnitTest
    {
        private CategoryService _sut;

        public CategoryServiceUnitTest()
        {
            _sut = new CategoryService();
        }

        [Fact]
        public void GetCategory_WhenWeightExceeds50_ShouldReturnReject()
        {
            // Arrange
            var weight = 100;
            var volume = 1;

            // Act
            var actual = _sut.GetCategory(weight, volume);

            // Assert
            Assert.Equal(Category.Reject, actual);
        }

        [Fact]
        public void GetCategory_WhenWeightExceeds10_ShouldReturnHeavy()
        {
            // Arrange
            var weight = 12;
            var volume = 1;

            // Act
            var actual = _sut.GetCategory(weight, volume);

            // Assert
            Assert.Equal(Category.Heavy, actual);
        }

        [Fact]
        public void GetCategory_WhenVolumeIsLessThan1500_ShouldReturnSmall()
        {
            // Arrange
            var weight = 9;
            var volume = 1400;

            // Act
            var actual = _sut.GetCategory(weight, volume);

            // Assert
            Assert.Equal(Category.Small, actual);
        }

        [Fact]
        public void GetCategory_WhenVolumeIsLessThan2500_ShouldReturnMedium()
        {
            // Arrange
            var weight = 9;
            var volume = 2400;

            // Act
            var actual = _sut.GetCategory(weight, volume);

            // Assert
            Assert.Equal(Category.Medium, actual);
        }

        [Fact]
        public void GetCategory_WhenVolumeIsGreaterThan2500_ShouldReturnLarge()
        {
            // Arrange
            var weight = 9;
            var volume = 2501;

            // Act
            var actual = _sut.GetCategory(weight, volume);

            // Assert
            Assert.Equal(Category.Large, actual);
        }
    }
}
