using System.ComponentModel.DataAnnotations.Schema;

namespace AeroSimFT.ViewModels
{
    public class Flights
    {
        private Int32? xpId = 1;
        private string? xpPlaneName = string.Empty;
        private string? departIdent = string.Empty;
        private string? destIdent = string.Empty;
        private string? departType = string.Empty;
        private string? destType;
        private string? departName;
        private string? destName;
        private string? departCountry = string.Empty;
        private string? destCountry = string.Empty;
        private string? departRegion;
        private Int32? departElevation = 0;
        private string? destRegion;
        private string? departCity;
        private string? destCity;
        private Int32? destElevation = 0;
        private Int32? distKM;
        private Int32? distMI;
        private Int32? distNMI;
        private string? flightTime;
        [NotMapped]
        private Nullable<Int32> airportType = 0;

        public Flights() { }
        public Flights(Int32 xpId, string xplaneName, string departIdent, string destIdent, string departType, string destType, string departName, string destName, string departCountry, string destCountry, string departRegion, Int32 departElevation, string destRegion, string departCity, string destCity, Int32 destElevation, Int32 distKM, Int32 distMI, Int32 distNMI, string flightTime, Int32 airportType)
        {
            XpId = xpId;
            XplaneName = xplaneName;
            DepartIdent = departIdent;
            DestIdent = destIdent;
            DepartType = departType;
            DestType = destType;
            DepartName = departName;
            DestName = destName;
            DepartCountry = departCountry;
            DestCountry = destCountry;
            DepartRegion = departRegion;
            DepartElevation = departElevation;
            DestRegion = destRegion;
            DepartCity = departCity;
            DestCity = destCity;
            DestElevation = destElevation;
            DistKM = distKM;
            DistMI = distMI;
            DistNMI = distNMI;
            FlightTime = flightTime;
            AirportType = airportType;

        }

        public Int32? XpId
        {
            get { return xpId; }
            set { xpId = value; }
        }
        public string? XplaneName
        {
            get { return xpPlaneName; }
            set { xpPlaneName = value; }
        }
        public string? DepartIdent
        {
            get { return departIdent; }
            set { departIdent = value; }
        }
        public string? DestIdent
        {
            get { return destIdent; }
            set { destIdent = value; }
        }
        public string? DepartType
        {
            get { return departType; }
            set { departType = value; }
        }
        public string? DestType
        {
            get { return destType; }
            set { destType = value; }
        }
        public string? DepartName
        {
            get { return departName; }
            set { departName = value; }
        }
        public string? DestName
        {
            get { return destName; }
            set { destName = value; }
        }
        public string? DepartCountry
        {
            get { return departCountry; }
            set { departCountry = value; }
        }
        public string? DestCountry
        {
            get { return destCountry; }
            set { destCountry = value; }
        }
        public string? DepartRegion
        {
            get { return departRegion; }
            set { departRegion = value; }
        }
        public Int32? DepartElevation
        {
            get { return departElevation; }
            set { departElevation = value; }
        }
        public string? DestRegion
        {
            get { return destRegion; }
            set { destRegion = value; }
        }
        public string? DepartCity
        {
            get { return departCity; }
            set { departCity = value; }
        }
        public string? DestCity
        {
            get { return destCity; }
            set { destCity = value; }
        }
        public Int32? DestElevation
        {
            get { return destElevation; }
            set { destElevation = value; }
        }
        public Int32? DistKM
        {
            get { return distKM; }
            set { distKM = value; }
        }
        public Int32? DistMI
        {
            get { return distMI; }
            set { distMI = value; }
        }
        public Int32? DistNMI
        {
            get { return distNMI; }
            set { distNMI = value; }
        }
        public string? FlightTime
        {
            get { return flightTime; }
            set { flightTime = value; }
        }
        public Int32? AirportType
        {
            get { return airportType; }
            set { airportType = value; }
        }
    }
}
