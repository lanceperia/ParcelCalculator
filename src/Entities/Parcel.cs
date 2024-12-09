using ParcelCalculator.Enums;

namespace ParcelCalculator.Entities
{
    public class Parcel
    {
        public decimal Weight { get; set; }
       
        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        public string Category { get; set; }
    }
}
