using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSimFT.ViewModels
{
    [Keyless]
    public class RandomFlightForm
    {
        private Int32 xpId = 1;
        private Int32 airportType = 0;
        private string departIdent = string.Empty;
        private string continent = string.Empty;
        private List<Continents> continentsList = new List<Continents>();
        private Int32 minMiles = 0;
        private Int32 maxMiles = 0;

        public RandomFlightForm() { }
        public RandomFlightForm(int xpId, Int32 airportType, string departIdent, string continent, List<Continents> continentsList, int minMiles, int maxMiles)
        {
            XpId = xpId;
            AirportType = airportType;
            DepartIdent = departIdent;
            Continent = continent;
            this.continentsList = continentsList;
            MinMiles = minMiles;
            MaxMiles = maxMiles;
        }

        public Int32 XpId
        {
            get { return xpId; }
            set { xpId = value; }
        }
        public Int32 AirportType
        {
            get { return airportType; }
            set { airportType = value; }
        }
        public string DepartIdent
        {
            get { return departIdent; }
            set { departIdent = value; }
        }
        public string Continent
        {
            get { return continent; }
            set { continent = value; }
        }
        public List<Continents> ContinentList { get { return continentsList; } }
        public Int32 MinMiles { get { return minMiles; } set { minMiles = value; } }
        public Int32 MaxMiles { get { return maxMiles; } set { maxMiles = value; } }
    }
    public class AircraftOptions
    {
        private Int32 acId = 0;
        private string xpName = string.Empty;
        private bool xpSelected = false;

        public AircraftOptions() { }
        public AircraftOptions(int acId, string xPName, bool xPSelected)
        {
            AcId = acId;
            XPName = xPName;
            XPSelected = xPSelected;
        }

        public Int32 AcId { get { return acId; } set { acId = value; } }
        public string XPName { get { return xpName; } set { xpName = value; } }
        public bool XPSelected { get { return xpSelected; } set { xpSelected = value; } }
    }
    public class AirportTypes
    {
        private Int32 typeid = 0;
        private string airportTypeName = string.Empty;
        private bool airportTypeSelected = false;

        public AirportTypes() { }

        public AirportTypes(int typeid, string airportTypeName, bool airportTypeSelected)
        {
            TypeId = typeid;
            AirportTypeName = airportTypeName;
            AirportTypeSelected = airportTypeSelected;
        }

        public Int32 TypeId { get { return typeid; } set { typeid = value; } }
        public string AirportTypeName { get { return airportTypeName; } set { airportTypeName = value; } }
        public bool AirportTypeSelected { get { return airportTypeSelected; } set { airportTypeSelected = value; } }
    }
}
