using AeroSimFT.Data;
using AeroSimFT.EFModels;
using AeroSimFT.ViewModels;
using AeroSimFT.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace AeroSimFT.Services
{
    public class XplaneServices
    {
        public static async Task<IEnumerable<XpFlightPlan>> GetSavedFlights()
        {
            using var context = new FlightSimContext();
            List<XpFlightPlan> flights = await context.XpFlightPlans
                .Include(a => a.Aircraft)
                .Where(f => f.DateFlown == null)
                .ToListAsync();

            return flights;
        }
        public static async Task<IEnumerable<XpFlightPlan>> GetFlownFlights()
        {
            using var context = new FlightSimContext();
            List<XpFlightPlan> flights = await context.XpFlightPlans
                .Include(a => a.Aircraft)
                .Where(f => f.DateFlown != null)
                .ToListAsync();

            return flights;
        }
        public static async Task<List<Flights>> GetRandomFlight(RandomFlightForm obj)
        {
            using var context = new FlightSimContext();

            List<Flights> result = new List<Flights>();

            GeneratedFlight gf = await new FlightGenerator().BuildFlight(obj.XpId, obj.DepartIdent, obj.AirportType, obj.Continent, obj.MinMiles, obj.MaxMiles);
            Flights t = new Flights();
            t.XpId = gf.AircraftId;
            t.XplaneName = gf.XplaneName;
            t.DepartIdent = gf.DepartIdent;
            t.DepartName = gf.DepartAirport;
            t.DepartType = gf.DepartAirportTypeString;
            t.DepartCity = gf.DepartCity;
            t.DepartRegion = gf.DepartRegion;
            t.DepartCountry = gf.DepartCountry;
            t.DepartElevation = gf.DepartElevation;
            t.DestIdent = gf.DestIdent;
            t.DestName = gf.DestAirport;
            t.DestType = gf.DestAirportTypeString;
            t.DestCity = gf.DestCity;
            t.DestRegion = gf.DestRegion;
            t.DestCountry = gf.DestCountry;
            t.DestElevation = gf.DestElevation;
            t.DestType = gf.DestAirportTypeString;
            t.DistNMI = gf.DistanceNm;
            t.FlightTime = gf.EstFlightTime;
            result.Add(t);

            return result!;
        }
        public static async Task<IEnumerable<SavedFlights>> SavedFlightsAsync()
        {
            List<SavedFlights> list = new List<SavedFlights>();
            IEnumerable<XpFlightPlan> data = await GetSavedFlights();
            int row = 0;

            foreach (XpFlightPlan d in data)
            {
                SavedFlights savedFlights = new SavedFlights();
                savedFlights.DateCreate = d.DateCreated;
                savedFlights.FlightId = d.FpId;
                savedFlights.AircraftName = d.Aircraft.AcName;
                string dAirport = d.DepartAirport + " (" + d.DepartIdent + ")";
                savedFlights.DepartAirport = dAirport;
                string citycounty1 = d.DepartCity + ", " + d.DepartRegion + ", " + d.DepartCountry;
                savedFlights.DepartAirportArea = citycounty1;
                string aAirport = d.DestAirport + " (" + d.DestIdent + ")";
                savedFlights.ArrivalAirport = aAirport;
                string citycounty2 = d.DestCity + ", " + d.DestRegion + ", " + d.DestCountry;
                savedFlights.ArrivalAirportArea = citycounty2;
                savedFlights.Distance = Convert.ToInt32(d.DistanceNm);
                savedFlights.EstFlightTime = d.EstFlightTime!;
                savedFlights.Selected = false;
                row++;
                list.Add(savedFlights);
            }
            return list;
        }
        public static async Task<bool> MarkFlightFlown(Int32 fId)
        {
            bool result = false;
            var id = fId;
            try
            {

                using var context = new FlightSimContext();
                DateTime df = DateTime.Now;
                await context.XpFlightPlans
                    .Where(f => f.FpId == fId)
                    .ExecuteUpdateAsync(b =>
                    b.SetProperty(f => f.DateFlown, df)
                    );
                result = true;

            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.StackTrace);
                Debug.WriteLine(e.Message + e.InnerException);
            }

            return result;
        }
        public static async Task<bool> MarkCrashedFlight(Int32 fId)
        {
            bool result = false;
            try
            {

                using var context = new FlightSimContext();
                DateTime df = DateTime.Now;
                await context.XpFlightPlans
                    .Where(f => f.FpId == fId)
                    .ExecuteUpdateAsync(b =>
                    b.SetProperty(f => f.PlaneCrash, true)
                    .SetProperty(f => f.DateFlown, df)
                    );
                result = true;

            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.StackTrace);
                Debug.WriteLine(e.Message + e.InnerException);
            }

            return result;
        }
        public static async Task<bool> DeleteSavedFlight(Int32 fId)
        {
            bool results = false;
            try
            {

                using var context = new FlightSimContext();
                await context.XpFlightPlans
                    .Where(f => f.FpId == fId)
                    .ExecuteDeleteAsync();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.StackTrace);
                Debug.WriteLine(e.Message + e.InnerException);
            }

            return results;
        }
        public static async Task<IEnumerable<FlightsFlown>> GetFlownFlightsAsync()
        {
            List<FlightsFlown> flownFlights = new List<FlightsFlown>();
            IEnumerable<XpFlightPlan> plan = await GetFlownFlights();

            foreach (XpFlightPlan p in plan)
            {
                FlightsFlown ff = new FlightsFlown();
                ff.DateCreate = p.DateCreated;
                ff.FlightId = p.FpId;
                ff.AircraftName = p.Aircraft.AcName;
                string dAirport = p.DepartAirport + " (" + p.DepartIdent + ")";
                ff.DepartAirport = dAirport;
                string citycounty1 = p.DepartCity + ", " + p.DepartRegion + ", " + p.DepartCountry;
                ff.DepartAirportArea = citycounty1;
                string aAirport = p.DestAirport + " (" + p.DestIdent + ")";
                ff.ArrivalAirport = aAirport;
                string citycounty2 = p.DestCity + ", " + p.DestRegion + ", " + p.DestCountry;
                ff.ArrivalAirportArea = citycounty2;
                ff.Distance = Convert.ToInt32(p.DistanceNm);
                ff.EstFlightTime = p.EstFlightTime;
                ff.Crashed = p.PlaneCrash;
                ff.DateFlown = p.DateFlown;
                flownFlights.Add(ff);
            }

            return flownFlights;
        }
        public static async Task<bool> SaveFlightPlanAsync(XpFlightPlan flightPlan)
        {
            bool result = false;
            try
            {
                using var context = new FlightSimContext();
                context.XpFlightPlans.Add(flightPlan);
                await context.SaveChangesAsync();
                result = true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.StackTrace);
                Debug.WriteLine(e.Message + e.InnerException);
            }
            return result;
        }
    }
}
