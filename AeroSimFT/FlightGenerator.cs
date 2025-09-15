using System;
using AeroSimFT.EFModels;
using AeroSimFT.Models;
using AeroSimFT.Services;

namespace AeroSimFT
{
    internal class FlightGenerator
    {
        internal async Task<GeneratedFlight> BuildFlight(Int32 acId, string apIdent = null!, Int32 apTypeId = 0, string continent = null!, Int32 minMiles = 0, Int32 maxMiles = 0)
        {
            RandomParams randParams = await BuildRandomParam(acId, apIdent, apTypeId, continent, minMiles, maxMiles);
            GeneratedFlight generated;
            AirportServices AirportServices = new AirportServices();
            Airport departure = await AirportServices.GetAirportByIdAsync(randParams.DepartureAirportId);
            Airport arrival = await AirportServices.RandomArrivalAirportAsync(randParams);
            Coordinates departCoords = new Coordinates((double)randParams.Coordinates!.Latitude, (double)randParams.Coordinates!.Longitude);
            Coordinates arrivalCoords = new Coordinates((double)arrival.LatitudeDeg!, (double)arrival.LongitudeDeg!);
            double distance = CoordinatesDistance.DistanceTo(departCoords, arrivalCoords, randParams.UnitOfLength);
            double time = (distance / randParams.CruiseSpeed);
            TimeSpan timeSpan = TimeSpan.FromHours(time);
            string formattedTime = timeSpan.ToString(@"hh\:mm\:ss");

            generated = new GeneratedFlight((int)randParams.AirCraftId, randParams.AirCraftName, departure.Ident, departure.AirportName, departure.Type.AirportTypeTitle, departure.Municipality, departure.Region.RegionName, departure.Country.Name, departure.ElevationFt, arrival.Ident, arrival.AirportName, arrival.Type.AirportTypeTitle, arrival.Municipality, arrival.Region.RegionName, arrival.Country.Name, arrival.ElevationFt, Convert.ToInt32(distance), formattedTime);

            return generated;

        }
        internal async Task<RandomParams> BuildRandomParam(Int32 acId, string apIdent = null!, Int32 airportType = 0, string continent = null!, Int32 minMiles = 0, Int32 maxMiles = 0)
        {
            AirportServices apService = new AirportServices();
            RandomParams randParams = new RandomParams();
            XpAircraft? aircraft = await AircraftServices.GetXpAircraftByIdAsync(acId);
            Airport airportObj = new Airport();
            Coordinates departCoords;

            // Set the aircraft parameters
            randParams.AirCraftId = acId;
            randParams.AirCraftName = aircraft!.AcName!;
            randParams.AirCraftGuid = aircraft!.AcGuid;
            randParams.MinLandingRunwayLength = (Int32)(aircraft!.MinLandingDist! * 1.2);
            randParams.MinRotateRunwayLength = (Int32)(aircraft!.MinTakeoffDist! * 1.2);
            randParams.MaxRange = (Int32)(aircraft!.ServiceRange - (aircraft!.ServiceRange * 32 / 100));
            randParams.CruiseSpeed = (double)aircraft!.MaxCruise;
            if (minMiles != 0)
                randParams.MinDistance = minMiles;
            if (maxMiles != 0)
            {
                randParams.MaxDistance = maxMiles;
            }
                
            else
            {
                randParams.MaxDistance = (Int32)(randParams.MaxRange);
            }
                
            // Set the departure airport parameters
            if (String.IsNullOrEmpty(apIdent))
            {

                if (airportType != 0)
                    randParams.AirportTypeId = airportType;
                if (!String.IsNullOrEmpty(continent))
                    randParams.Continent = continent;


                airportObj = await apService.RandomStartAsync(randParams);
                departCoords = new Coordinates((double)airportObj.LatitudeDeg!, (double)airportObj.LongitudeDeg!);
                randParams.DepartureAirportId = airportObj.AirportId;
                randParams.AirportTypeId = (int)airportObj.TypeId!;
                randParams.Coordinates = departCoords;


            }
            else // if an airport ident is provided, use it
            {
                airportObj = await AirportServices.GetAirportByIdentAsync(apIdent);
                departCoords = new Coordinates((double)airportObj.LatitudeDeg!, (double)airportObj.LongitudeDeg!);
                randParams.DepartureAirportId = airportObj.AirportId;
                randParams.AirportTypeId = (int)airportObj.TypeId!;
                randParams.Coordinates = departCoords;
            }

            return randParams;
        }
    }
}
