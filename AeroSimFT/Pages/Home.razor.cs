using AeroSimFT.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSimFT.Pages
{
    public partial class Home
    {
        static IQueryable<SavedFlights>? items;

        List<SavedFlights>? details = new List<SavedFlights>();
        SavedFlights x = new SavedFlights();

        record Flight(int FlightId)
        {
            public bool Selected { get; set; }
        };

        protected override async Task OnInitializedAsync()
        {
            AppState.IndexPage = this;

            items = (await Services.XplaneServices.SavedFlightsAsync()).AsQueryable();

        }
        IQueryable<SavedFlights>? FileteredItems => items?.Where(f => string.IsNullOrEmpty(aircraftFilter) || f.AircraftName.Contains(aircraftFilter, StringComparison.OrdinalIgnoreCase));

        private void HandleAircraftFilter(ChangeEventArgs args)
        {
            if (args.Value is string value)
            {
                aircraftFilter = value;
            }
        }
        private void HandleClearFilter()
        {
            if (string.IsNullOrEmpty(aircraftFilter))
            {
                aircraftFilter = string.Empty;
            }
        }
        private async Task HandleCloseFilterAsync(KeyboardEventArgs e)
        {
            if (e.Key == "Escape")
            {
                aircraftFilter = string.Empty;

            }
            if (e.Key == "Enter" && grid is not null)
            {
                await grid.CloseColumnOptionsAsync();
            }
        }

        private void ViewDetails((SavedFlights Item, bool Selected) e)
        {
            items?.ToList().ForEach(i => i.Selected = false);
            e.Item.Selected = true;
            details?.Clear();
            foreach (var it in items!.Where(i => i.Selected == true))
            {
                x.FlightId = it.FlightId;
                SavedFlights sf = new SavedFlights();
                sf.AircraftName = it.AircraftName;
                sf.ArrivalAirport = it.ArrivalAirport;
                sf.ArrivalAirportArea = it.ArrivalAirportArea;
                sf.DepartAirport = it.DepartAirport;
                sf.DepartAirportArea = it.DepartAirportArea;
                sf.Distance = it.Distance;
                sf.EstFlightTime = it.EstFlightTime;
                details?.Add(sf);
            }
        }
        public async Task MarkAsFlown(Int32 fid)
        {
            bool result = await Services.XplaneServices.MarkFlightFlown(fid);
            this.StateHasChanged();
            navigationManager.NavigateTo("/flownflights");
        }
        public async Task MarkCrashed(Int32 fid)
        {
            bool result = await Services.XplaneServices.MarkCrashedFlight(fid);
            this.StateHasChanged();
            message = string.Empty;
            details?.Clear();
            items = (await Services.XplaneServices.SavedFlightsAsync()).AsQueryable();
        }
        public async Task DeleteSavedFlight(Int32 fid)
        {
            bool result = await Services.XplaneServices.DeleteSavedFlight(fid);
            this.StateHasChanged();
            message = string.Empty;
            details?.Clear();
            items = (await Services.XplaneServices.SavedFlightsAsync()).AsQueryable();
        }
    }
}
