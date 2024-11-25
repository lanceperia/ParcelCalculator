using ParcelCalculator.Enums;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Strategies
{
    public class WeightCategoryStrategy : ICategoryStrategy
    {
        public Category GetCategory(decimal weight, decimal volume)
        {
            if (weight > 50)
                return Category.Reject;
            if (weight > 10)
                return Category.Heavy;

            return Category.None;
        }
    }
}
