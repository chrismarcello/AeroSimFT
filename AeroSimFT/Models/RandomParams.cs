using AeroSimFT.EFModels;

namespace AeroSimFT.Models
{
    public class RandomParams
    {
        public Int32 AirCraftId { get; set; } = 4;
        public String AirCraftName { get; set; } = string.Empty;
        public String AirCraftGuid { get; set; }
        public Int32 MaxRange { get; set; } = 500; // in nautical miles
        public double CruiseSpeed { get; set; } = 140.0; // in knots
        public String Continent { get; set; } = string.Empty;
        public String DepartureAirportIdent { get; set; } = string.Empty;
        public Int32 DepartureAirportId { get; set; } = 0;
        public Int32 AirportTypeId { get; set; } = 2; // 1 = small, 2 = medium, 3 = large
        public Int32 MinRotateRunwayLength { get; set; } = 1500; // in feet
        public Int32 MinLandingRunwayLength { get; set; } = 1000; // in feet
        public UnitOfLength UnitOfLength { get; set; } = UnitOfLength.NauticalMiles;
        public double MinDistance { get; set; } = 50.0;
        public double MaxDistance { get; set; } = 200.0;
        public Coordinates? Coordinates { get; set; }
    }
}
