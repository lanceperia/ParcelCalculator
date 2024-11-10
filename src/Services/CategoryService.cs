using ParcelCalculator.Enums;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Services
{
    public class CategoryService : ICategoryService
    {
        public Category GetCategory(decimal weight, decimal volume)
        {
            if (weight > 50)
                return Category.Reject;
            if (weight > 10)
                return Category.Heavy;

            if (volume < 1500)
                return Category.Small;
            if (volume < 2500)
                return Category.Medium;
            if (volume >= 2500)
                return Category.Large;

            return Category.Reject;
        }
    }
}
