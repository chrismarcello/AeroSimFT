using AeroSimFT.EFModels;
using AeroSimFT.Services;
using AeroSimFT.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSimFT.Pages
{
    public partial class RandomFlight
    {
        private List<Continents>? contList;
        private List<AircraftOptions>? xpList = new List<AircraftOptions>();
        IEnumerable<Flights>? flightList;
        private List<AirportTypes>? airportTypeList = new List<AirportTypes>();
        RandomFlightForm obj = new RandomFlightForm();


        protected override async Task OnInitializedAsync()
        {
            AppState.RandomFlight = this;
            contList = await LocationServices.GetContinents();
            xpList = await AircraftServices.GetXpAircraftDropDownAsync();
            airportTypeList = await AirportServices.GetAirportTypeAsync();
        }
        protected async Task GenerateNewFlight()
        {
            flightList = null;
            flightList = await Task.Run(() => XplaneServices.GetRandomFlight(obj));
        }
        protected async void SaveFlight()
        {
            XpFlightPlan objSave = new XpFlightPlan();
            foreach (var i in flightList!)
            {
                objSave.DepartIdent = i.DepartIdent;
                objSave.AircraftId = Convert.ToInt32(i.XpId);
                objSave.DepartAirport = i.DepartName;
                objSave.DepartCity = i.DepartCity;
                objSave.DepartRegion = i.DepartRegion;
                objSave.DepartCountry = i.DepartCountry;
                objSave.DestIdent = i.DestIdent;
                objSave.DestAirport = i.DestName;
                objSave.DestCity = i.DestCity;
                objSave.DestRegion = i.DestRegion;
                objSave.DestCountry = i.DestCountry;
                objSave.DistanceNm = i.DistNMI;
                objSave.EstFlightTime = i.FlightTime;
                objSave.DateCreated = DateTime.Now;
            }
            bool result = await XplaneServices.SaveFlightPlanAsync(objSave);
            if (result)
            {
                navigationManager.NavigateTo("/");
            }

        }
    }
}
