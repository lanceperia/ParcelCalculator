using ParcelCalculator.Entities;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Strategies
{
    public class RejectedParcelStrategy : IPricingStrategy
    {
        public decimal? CalculateCost(Parcel parcel)
        {
            if (parcel.Weight > 50)
            {
                return null;
            }

            return 0;
        }
    }
}
