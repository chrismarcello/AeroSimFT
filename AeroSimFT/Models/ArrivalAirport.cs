using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSimFT.Models
{
    internal class ArrivalAirport
    {
        public Int32 AirportId { get; set; }
        public Int32 TypeId { get; set; }
        public UnitOfLength UnitOfLength { get; set; } = UnitOfLength.NauticalMiles;
        public Coordinates? Coordinates { get; set; }
        public double Distance { get; set; }
        Guid Guid { get; set; } = Guid.NewGuid();
    }
}
