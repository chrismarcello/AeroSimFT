using AeroSimFT.Data;
using AeroSimFT.EFModels;
using AeroSimFT.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSimFT.Services
{
    public class AircraftServices
    {
        public static async Task<List<AircraftOptions>> GetXpAircraftAsync()
        {
            List<AircraftOptions> af = new List<AircraftOptions>();
            using var context = new FlightSimContext();
            List<XpAircraft> aircraft = await context.XpAircrafts.ToListAsync();
            foreach (var a in aircraft)
            {
                AircraftOptions options = new AircraftOptions();
                options.AcId = a.AcId;
                options.XPName = a.AcName;
                options.XPSelected = false;
                af.Add(options);
            }

            return af;
        }
    }
}
