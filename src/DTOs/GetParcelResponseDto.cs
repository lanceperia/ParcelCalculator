using Microsoft.AspNetCore.Mvc;
using ParcelCalculator.Enums;

namespace ParcelCalculator.DTOs
{
    /// <summary>
    /// Response DTO for GetParcelDetails request
    /// </summary>
    public class GetParcelResponseDto 
    {
        /// <summary>
        /// Returns the category of parcel
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Returns the cost of parcel
        /// </summary>
        public string Cost { get; set; }
    }
}
