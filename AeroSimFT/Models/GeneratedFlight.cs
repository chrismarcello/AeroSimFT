using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSimFT.Models
{
    public class GeneratedFlight
    {
        public GeneratedFlight(int aircraftId, string xplaneName, string? departIdent, string? departAirport, string departAirporTypeString, string? departCity, string? departRegion, string? departCountry, int? departElevation, string? destIdent, string? destAirport, string destAirportTypeString, string? destCity, string? destRegion, string? destCountry, int? destElevation, int? distanceNm, string? estFlightTime)
        {
            AircraftId = aircraftId;
            XplaneName = xplaneName;
            DepartIdent = departIdent;
            DepartAirport = departAirport;
            DepartAirportTypeString = departAirporTypeString;
            DepartCity = departCity;
            DepartRegion = departRegion;
            DepartCountry = departCountry;
            DepartElevation = departElevation;
            DestIdent = destIdent;
            DestAirport = destAirport;
            DestAirportTypeString = destAirportTypeString;
            DestCity = destCity;
            DestRegion = destRegion;
            DestCountry = destCountry;
            DestElevation = destElevation;
            DistanceNm = distanceNm;
            EstFlightTime = estFlightTime;
        }

        public int AircraftId { get; private set; }

        public string? XplaneName { get; private set; }

        public string? DepartIdent { get; private set; }

        public string? DepartAirport { get; private set; }

        public string DepartAirportTypeString { get; private set; } = string.Empty;

        public string? DepartCity { get; private set; }

        public string? DepartRegion { get; private set; }

        public string? DepartCountry { get; private set; }

        public Int32? DepartElevation { get; private set; }

        public string? DestIdent { get; private set; }

        public string? DestAirport { get; private set; }

        public string DestAirportTypeString { get; private set; } = string.Empty;

        public string? DestCity { get; private set; }

        public string? DestRegion { get; private set; }

        public string? DestCountry { get; private set; }

        public Int32? DestElevation { get; private set; }

        public int? DistanceNm { get; private set; }

        public string? EstFlightTime { get; private set; }
    }
}
