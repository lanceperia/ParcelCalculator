using ParcelCalculator.Entities;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Strategies
{
    public class LargeParcelStrategy : IPricingStrategy
    {
        public decimal? CalculateCost(Parcel parcel)
        {
            var volume = parcel.Height * parcel.Width * parcel.Depth;

            return volume * 0.03m;
        }
    }
}
