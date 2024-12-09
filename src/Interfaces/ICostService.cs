using ParcelCalculator.DTOs;
using ParcelCalculator.Entities;
using ParcelCalculator.Enums;

namespace ParcelCalculator.Interfaces
{
    /// <summary>
    /// Interface for computing service
    /// </summary>
    public interface ICostService
    {
        string GetCost(Parcel parcel);
    }
}
