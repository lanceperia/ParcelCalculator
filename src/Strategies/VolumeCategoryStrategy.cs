using ParcelCalculator.Enums;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Strategies
{
    public class VolumeCategoryStrategy : ICategoryStrategy
    {
        public Category GetCategory(decimal weight, decimal volume)
        {
            if (volume < 1500)
                return Category.Small;
            if (volume < 2500)
                return Category.Medium;
            if (volume >= 2500)
                return Category.Large;

            return Category.None;
        }
    }
}
