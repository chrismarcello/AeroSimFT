using AeroSimFT.EFModels;
using AeroSimFT.Services;
using FisSst.BlazorMaps;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AeroSimFT.Pages.Airports
{
    public partial class AirportDetails
    {
        [Parameter]
        public int Id { get; set; }
        IQueryable<Airport>? airportDetails;
        string? TheAirportName => airportDetails?.FirstOrDefault()?.AirportName;
        
        public static double latdeg { get; set; } = 0.000;
        public static double longdeg { get; set; } = 0.000;

        private LatLng center;
        private Map mapRef;
       
        private MapOptions mapOptions;
        protected override async Task OnInitializedAsync()
        {
            AppState.AirportDetails = this;

            airportDetails = (await Services.AirportServices.GetAirportDetailsAsync(Id)).AsQueryable();

            latdeg = airportDetails?.FirstOrDefault()?.LatitudeDeg ?? 0.000;
            longdeg = airportDetails?.FirstOrDefault()?.LongitudeDeg ?? 0.000;

            this.center = new LatLng(latdeg, longdeg);
            
            this.mapOptions = new MapOptions()
            {
                DivId = "mapId",
                Center = center,
                Zoom = 13,
                UrlTileLayer = "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
                SubOptions = new MapSubOptions()
                {
                    Attribution = "&copy; <a lhref='http://www.openstreetmap.org/copyright'>OpenStreetMap</a>",
                    MaxZoom = 18,
                    TileSize = 512,
                    ZoomOffset = -1,
                }
            };


        }     

    }
}
