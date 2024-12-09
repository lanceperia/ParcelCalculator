using ParcelCalculator.Entities;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Services
{
    /// <summary>
    /// Service for computing costs
    /// </summary>
    public class CostService : ICostService
    {
        private readonly IEnumerable<IPricingStrategy> _pricingStrategies;
        public CostService(IEnumerable<IPricingStrategy> pricingStrategies)
        {
            _pricingStrategies = pricingStrategies;
        }
        public string GetCost(Parcel parcel)
        {
            foreach (var strategy in _pricingStrategies)
            {
                var cost = strategy.CalculateCost(parcel);

                if (cost == null)
                    break;

                if (cost > 0)
                {
                    parcel.Category = strategy.GetType().Name.Replace("ParcelStrategy", "");
                    return cost.Value.ToString("C");
                }
            }

            parcel.Category = "Rejected";
            return "N/A";
        }
    }
}
