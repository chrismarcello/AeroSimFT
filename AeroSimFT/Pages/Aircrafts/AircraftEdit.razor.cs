using AeroSimFT.EFModels;
using AeroSimFT.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace AeroSimFT.Pages.Aircrafts
{
    public partial class AircraftEdit
    {
        [Parameter]
        public int Id { get; set; }
        FluentTab? changedto;
        private XpAircraft? aircraftDetails = new XpAircraft();
        string? TheAircraftName = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            AppState.AircraftEdit = this;
            aircraftDetails = await AircraftServices.GetXpAircraftByIdAsync(Id);
            TheAircraftName = aircraftDetails?.AcName;
        }
        private void HandleOnTabChange(FluentTab tab)
        {
            changedto = tab;
        }
        private void Submit()
        {
            TheAircraftName = aircraftDetails?.AcName;
        }
    }
}
