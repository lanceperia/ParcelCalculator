namespace ParcelCalculator.DTOs
{
    /// <summary>
    /// Request DTO for GetParcelDetails request
    /// </summary>
    public class GetParcelRequestDto
    {
        /// <summary>
        /// Weight in kilogram (kg)
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// Height in centimeter (cm)
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// Width in centimeter (cm)
        /// </summary>
        public decimal Width { get; set; }

        /// <summary>
        /// Depth in centimeter (cm)
        /// </summary>
        public decimal Depth { get; set; }
    }
}
