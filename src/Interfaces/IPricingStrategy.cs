using ParcelCalculator.Entities;

namespace ParcelCalculator.Interfaces
{
    public interface IPricingStrategy
    {
        decimal? CalculateCost(Parcel parcel);
    }
}
