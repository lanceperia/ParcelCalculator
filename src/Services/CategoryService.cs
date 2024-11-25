using ParcelCalculator.Enums;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IEnumerable<ICategoryStrategy> _categoryStrategies;
        public CategoryService(IEnumerable<ICategoryStrategy> categoryStrategies)
        {
            _categoryStrategies = categoryStrategies;
        }
        public Category GetCategory(decimal weight, decimal volume)
        {
            foreach (var strategy in _categoryStrategies)
            {
                var category = strategy.GetCategory(weight, volume);
                if (category != Category.None && category != Category.Reject)
                {
                    return category;
                }
            }

            return Category.Reject;
        }
    }
}
