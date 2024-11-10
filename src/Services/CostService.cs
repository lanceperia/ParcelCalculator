using ParcelCalculator.Enums;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Services
{
    /// <summary>
    /// Service for computing costs
    /// </summary>
    public class CostService : ICostService
    {
        public string GetCost(Category category, decimal weight, decimal volume)
        {
            switch (category)
            {
                case Category.Heavy:
                    return (weight * 15).ToString("C");
                case Category.Small:
                    return (volume * 0.05m).ToString("C");
                case Category.Medium:
                    return (volume * 0.04m).ToString("C");
                case Category.Large:
                    return (volume * 0.03m).ToString("C");
                default:
                    return "N/A";
            }
        }
    }
}
