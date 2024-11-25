using ParcelCalculator.Enums;

namespace ParcelCalculator.Interfaces
{
    public interface ICategoryStrategy
    {
        Category GetCategory(decimal weight, decimal volume);
    }
}
