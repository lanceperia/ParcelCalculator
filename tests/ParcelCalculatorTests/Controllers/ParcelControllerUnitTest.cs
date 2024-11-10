using NSubstitute;
using ParcelCalculator.Controllers;
using ParcelCalculator.DTOs;
using ParcelCalculator.Enums;
using ParcelCalculator.Exceptions;
using ParcelCalculator.Interfaces;

namespace ParcelCalculatorTests.Controllers
{
    public class ParcelControllerUnitTest
    {
        private ParcelController sut;
        private readonly ICostService _costService;
        private readonly ICategoryService _categoryService;

        public ParcelControllerUnitTest()
        {
            _costService = Substitute.For<ICostService>();
            _categoryService = Substitute.For<ICategoryService>();

            sut = new ParcelController(_costService, _categoryService);
        }

        [Fact]
        public void GetParcelDetails_WhenAllParamsIsInvalid_ShouldThrowException()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<ParameterValidationException>(() => sut.GetParcelDetails(new GetParcelRequestDto()));
        }

        [Theory]
        [InlineData(-1, 1, 1, 1)]
        [InlineData(1, -1, 1, 1)]
        [InlineData(1, 1, -1, 1)]
        [InlineData(1, 1, 1, -1)]
        public void GetParcelDetails_WhenParamsHasNegativeValues_ShouldThrowException(int weight, int width, int height, int depth)
        {
            // Arrange
            var dto = new GetParcelRequestDto()
            {
                Depth = depth,
                Height = height,
                Weight = weight,
                Width = width
            };

            // Act & Assert
            Assert.Throws<ParameterValidationException>(() => sut.GetParcelDetails(new GetParcelRequestDto()));
        }

        [Fact]
        public void GetParcelDetails_WhenCategoryReturnsReject_ShouldReturnRejectAndCostIsNotApplicable()
        {
            // Arrange
            var dto = new GetParcelRequestDto()
            {
                Weight = 110,
                Height = 20,
                Width = 55,
                Depth = 120
            };
            var expectedCategory = Category.Reject;
            var expectedCost = "N/A";

            _categoryService.GetCategory(Arg.Any<decimal>(), Arg.Any<decimal>()).Returns(expectedCategory);
            _costService.GetCost(expectedCategory, Arg.Any<decimal>(), Arg.Any<decimal>()).Returns(expectedCost);

            // Act
            var actual = sut.GetParcelDetails(dto);

            // Assert
            Assert.Equal("Rejected", actual.Category);
            Assert.Equal(expectedCost.ToString(), actual.Cost);
        }

        [Theory]
        [InlineData(Category.Heavy)]
        [InlineData(Category.Small)]
        [InlineData(Category.Medium)]
        [InlineData(Category.Large)]
        public void GetParcelDetails_WhenCategoryIsNotReject_ShouldReturnCategoryAndCost(Category category)
        {
            // Arrange
            var dto = new GetParcelRequestDto()
            {
                Weight = 1,
                Height = 2,
                Width = 3,
                Depth = 4
            };
            var expectedCategory = category;
            var expectedCost = "$44";

            _categoryService.GetCategory(Arg.Any<decimal>(), Arg.Any<decimal>()).Returns(expectedCategory);
            _costService.GetCost(expectedCategory, Arg.Any<decimal>(), Arg.Any<decimal>()).Returns(expectedCost);

            // Act
            var actual = sut.GetParcelDetails(dto);

            // Assert
            Assert.Equal($"{expectedCategory} Parcel", actual.Category);
            Assert.Equal(expectedCost.ToString(), actual.Cost);
        }
    }
}
