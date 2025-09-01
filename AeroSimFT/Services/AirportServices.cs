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
    public class AirportServices
    {
        public static async Task<List<AirportTypes>> GetAirportTypeAsync()
        {
            using var context = new FlightSimContext();
            List<AirportTypes> airportTypes = new List<AirportTypes>();
            List<AirportType> at = await context.AirportTypes.ToListAsync();

            foreach (AirportType airportType in at)
            {
                AirportTypes ats = new AirportTypes();
                ats.TypeId = airportType.TypeId;
                ats.AirportTypeName = airportType.AirportTypeTitle!;
                ats.AirportTypeSelected = false;
                airportTypes.Add(ats);
            }

            return airportTypes;
        }
        public static async Task<List<Airport>> FindAirportsAsync(string search)
        {
            using var context = new FlightSimContext();

            List<Airport> ap = await context.Airports.OrderBy(a => a.AirportName)
                                                     .Where(a => a.AirportName != null && a.AirportName.Contains(search) || a.Ident!.Contains(search))
                                                     .Include(r => r.Region)
                                                     .Include(c => c.Country)
                                                     .Include(t => t.Type)
                                                     .ToListAsync();
            return ap;
        }
        public static async Task<List<Airport>> GetAirportDetailsAsync(Int32 Id)
        {
            using var context = new FlightSimContext();

            List<Airport> ap = await context.Airports.OrderBy(a => a.AirportName)
                                                     .Where(a => a.AirportId.Equals(Id))
                                                     .Include(r => r.Region)
                                                     .Include(c => c.Country)
                                                     .Include(t => t.Type)
                                                     .ToListAsync();
            return ap;
        }
    }
}
