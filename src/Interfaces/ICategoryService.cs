using ParcelCalculator.Enums;

namespace ParcelCalculator.Interfaces
{
    public interface ICategoryService
    {
        Category GetCategory(decimal weight, decimal volume);
    }
}
