using ParcelCalculator.Entities;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Strategies
{
    public class HeavyParcelStrategy : IPricingStrategy
    {
        public decimal? CalculateCost(Parcel parcel)
        {
            if (parcel.Weight > 10)
            {
                return parcel.Weight * 15;
            }

            return 0;
        }
    }
}
