using ParcelCalculator.Entities;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Strategies
{
    public class SmallParcelStrategy : IPricingStrategy
    {
        public decimal? CalculateCost(Parcel parcel)
        {
            var volume = parcel.Height * parcel.Width * parcel.Depth;
            if (volume < 1500)
            {
                return volume * 0.05m;
            }

            return 0;
        }
    }
}
