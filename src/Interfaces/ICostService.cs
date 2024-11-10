using ParcelCalculator.DTOs;
using ParcelCalculator.Enums;

namespace ParcelCalculator.Interfaces
{
    /// <summary>
    /// Interface for computing service
    /// </summary>
    public interface ICostService
    {
        string GetCost(Category category, decimal weight, decimal volume);
    }
}
