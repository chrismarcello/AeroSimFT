using AeroSimFT.Data;
using AeroSimFT.EFModels;
using AeroSimFT.Models;
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
        // Random Flight Methods
        public async Task<Airport> RandomStartAsync(RandomParams randomParams)
        {
            Int32 result = 0;
            using var db = new FlightSimContext();

            var longestRunway = db.Runways
                  .GroupBy(runway => runway.AirportId)
                  .Select(group => new
                  {
                      AirportId = group.Key,
                      MaxRunwayLength = group.Max(rw => rw.LengthFt),


                  })
                  .Where(r => r.MaxRunwayLength > randomParams.MinRotateRunwayLength);

            if (randomParams.AirportTypeId == 0 && String.IsNullOrEmpty(randomParams.Continent))
            {
                var query = await db.Airports
                    .Join(longestRunway,
                          airport => airport.AirportId,
                          runway => runway.AirportId,
                          (airport, runway) => new { Airport = airport, RunwayLength = runway.MaxRunwayLength })
                    .Where(ar => ar.Airport.TypeId.Equals(1) || ar.Airport.TypeId.Equals(2) || ar.Airport.TypeId.Equals(3))
                    .OrderBy(ar => EF.Functions.Random())
                    .Select(ar => new
                    {
                        ar.Airport,
                        ar.RunwayLength
                    })
                    .FirstOrDefaultAsync();
                result = query!.Airport.AirportId;
            }
            else if (randomParams.AirportTypeId == 0 && !String.IsNullOrEmpty(randomParams.Continent))
            {
                var query = await db.Airports
                    .Join(longestRunway,
                          airport => airport.AirportId,
                          runway => runway.AirportId,
                          (airport, runway) => new { Airport = airport, RunwayLength = runway.MaxRunwayLength })
                    .Where(ar => ar.Airport.Continent == randomParams.Continent)
                    .Where(br => br.Airport.TypeId.Equals(1) || br.Airport.TypeId.Equals(2) || br.Airport.TypeId.Equals(3))
                    .OrderBy(ar => EF.Functions.Random())
                    .Select(ar => new
                    {
                        ar.Airport,
                        ar.RunwayLength
                    })
                    .FirstOrDefaultAsync();
                result = query!.Airport.AirportId;
            }
            else if (randomParams.AirportTypeId != 0 && !String.IsNullOrEmpty(randomParams.Continent))
            {

                var query = await db.Airports
                       .Join(longestRunway,
                             airport => airport.AirportId,
                             runway => runway.AirportId,
                             (airport, runway) => new { Airport = airport, RunwayLength = runway.MaxRunwayLength })
                       .Where(ar => ar.Airport.TypeId == randomParams.AirportTypeId && ar.Airport.Continent == randomParams.Continent)
                       .OrderBy(ar => EF.Functions.Random())
                       .Select(ar => new
                       {
                           ar.Airport,
                           ar.RunwayLength
                       })
                       .FirstOrDefaultAsync();
                result = query!.Airport.AirportId;

            }
            else
            {
                var query = await db.Airports
                    .Join(longestRunway,
                          airport => airport.AirportId,
                          runway => runway.AirportId,
                          (airport, runway) => new { Airport = airport, RunwayLength = runway.MaxRunwayLength })
                    .Where(ar => ar.Airport.TypeId == randomParams.AirportTypeId)
                    .OrderBy(ar => EF.Functions.Random())
                    .Select(ar => new
                    {
                        ar.Airport,
                        ar.RunwayLength
                    })
                    .FirstOrDefaultAsync();
                result = query!.Airport.AirportId;

            }
            Airport? ap = await db!.Airports!.OrderBy(a => a!.AirportName)
                                                     .Where(a => a!.Ident != null && a!.AirportId!.Equals(result))
                                                     .Include(r => r!.Region)
                                                     .Include(c => c!.Country)
                                                     .Include(t => t!.Type)
                                                     .FirstOrDefaultAsync();
            return ap!;
        }
        public async Task<Airport> RandomArrivalAirportAsync(RandomParams randomParams)
        {
            Airport? ap = new Airport();

            using var db = new FlightSimContext();
            var longestRunway = db.Runways
                  .GroupBy(runway => runway.AirportId)
                  .Select(group => new
                  {
                      AirportId = group.Key,
                      MaxRunwayLength = group.Max(rw => rw.LengthFt),


                  })
                  .Where(r => r.MaxRunwayLength > randomParams.MinRotateRunwayLength);
            var query = await db.Airports
                    .Join(longestRunway,
                          airport => airport.AirportId,
                          runway => runway.AirportId,
                          (airport, runway) => new { Airport = airport, RunwayLength = runway.MaxRunwayLength })
                    .Select(ar => new
                    {
                        ar.Airport,
                        ar.RunwayLength
                    }).ToListAsync();

            List<ArrivalAirport> arrivalAirports = new List<ArrivalAirport>();
            foreach (var item in query)
            {
                Coordinates departCoords = new Coordinates((double)randomParams.Coordinates!.Latitude, (double)randomParams.Coordinates!.Longitude);
                Coordinates arrivalCoords = new Coordinates((double)item.Airport.LatitudeDeg!, (double)item.Airport.LongitudeDeg!);
                double distance = CoordinatesDistance.DistanceTo(departCoords, arrivalCoords, randomParams.UnitOfLength);
                ArrivalAirport arrivalAirport = new ArrivalAirport
                {
                    AirportId = item.Airport.AirportId,
                    Distance = (double)distance,
                    Coordinates = arrivalCoords,
                    TypeId = (int)item.Airport.TypeId!,
                    UnitOfLength = randomParams.UnitOfLength
                };
                arrivalAirports.Add(arrivalAirport);
            }
            var filteredQuery = arrivalAirports
                .Where(a => a.AirportId != randomParams.DepartureAirportId)
                .Where(b => b.Distance >= randomParams.MinDistance && b.Distance <= randomParams.MaxDistance)
                .Where(c => c.TypeId.Equals(1) || c.TypeId.Equals(2) || c.TypeId.Equals(3))
                .OrderBy(g => Guid.NewGuid())
                .FirstOrDefault();

            if (filteredQuery != null)
            {
                ap = await db!.Airports!.OrderBy(a => a!.AirportName)
                                                     .Where(a => a!.Ident != null && a!.AirportId!.Equals(filteredQuery.AirportId))
                                                     .Include(r => r!.Region)
                                                     .Include(c => c!.Country)
                                                     .Include(t => t!.Type)
                                                     .FirstOrDefaultAsync();
            }
            return ap!;
        }
        public static async Task<Airport> GetAirportByIdentAsync(string search)
        {
            using var context = new FlightSimContext();
            
            Airport? ap = await context!.Airports!.OrderBy(a => a!.AirportName)
                                                     .Where(a => a!.Ident != null && a!.Ident!.Equals(search))
                                                     .Include(r => r!.Region)
                                                     .Include(c => c!.Country)
                                                     .Include(t => t!.Type)
                                                     .FirstOrDefaultAsync();
            return ap!;
        }
        public static async Task<Airport> GetAirportByIdAsync(Int32 id)
        {
            using var context = new FlightSimContext();

            Airport? ap = await context!.Airports!.OrderBy(a => a!.AirportName)
                                                     .Where(a => a!.Ident != null && a!.AirportId!.Equals(id))
                                                     .Include(r => r!.Region)
                                                     .Include(c => c!.Country)
                                                     .Include(t => t!.Type)
                                                     .FirstOrDefaultAsync();
            return ap!;
        }
    }
}
