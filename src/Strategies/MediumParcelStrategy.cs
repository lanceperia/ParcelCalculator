using ParcelCalculator.Entities;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Strategies
{
    public class MediumParcelStrategy : IPricingStrategy
    {
        public decimal? CalculateCost(Parcel parcel)
        {
            var volume = parcel.Height * parcel.Width * parcel.Depth;
            if (volume < 2500)
            {
                return volume * 0.04m;
            }

            return 0;
        }
    }
}
