using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components;
using AeroSimFT.Services;
using AeroSimFT.EFModels;
using LeafletForBlazor;

namespace AeroSimFT.Pages.Airports
{
    public partial class AirportDetails
    {
        [Parameter]
        public int Id { get; set; }
        IQueryable<Airport>? airportDetails;
        string? TheAirportName => airportDetails?.FirstOrDefault()?.AirportName;
        RealTimeMap realTimeMap = new RealTimeMap();
        public static double latdeg { get; set; } = 0.000;
        public static double longdeg { get; set; } = 0.000;
        protected override async Task OnInitializedAsync()
        {
            AppState.AirportDetails = this;

            airportDetails = (await Services.AirportServices.GetAirportDetailsAsync(Id)).AsQueryable();

            latdeg = airportDetails?.FirstOrDefault()?.LatitudeDeg ?? 0.000;
            longdeg = airportDetails?.FirstOrDefault()?.LongitudeDeg ?? 0.000;

            RealTimeMap.LoadParameters parameters = new RealTimeMap.LoadParameters
            {
                location = new RealTimeMap.Location
                {
                    latitude = await GetLargerArea(latdeg),
                    longitude = await GetLargerArea(longdeg)
                },
                zoomLevel = 18,
                basemap = new RealTimeMap.Basemap
                {
                    basemapLayers = new List<RealTimeMap.BasemapLayer>
                    {
                        new RealTimeMap.BasemapLayer
                        {
                            url = "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
                            attribution = "© OpenStreetMap contributors",
                            minZoom = 1,
                            maxZoom = 19
                        },
                        new RealTimeMap.BasemapLayer()
                        {
                        url = "https://tile.opentopomap.org/{z}/{x}/{y}.png",
                        attribution = "Open Topo",
                        title = "Open Topo",
                        detectRetina = true
                        },
                    }
                }
            };
        }
        private async Task AddMarker()
        {
            realTimeMap.Geometric.Points.Appearance(item => item.type == "Airfield").pattern = new RealTimeMap.PointSymbol
            {
                radius = 10,
                color = "blue",
                fillColor = "yellow",
                fillOpacity = 0.8,
                opacity = 1.0,
                weight = 2  //add line weight, default is 0
            };


            var point = new RealTimeMap.StreamPoint
            {
                type = "Airfield",
                latitude = latdeg,
                longitude = longdeg,

            };
            await realTimeMap.Geometric.Points.add(point);
        }
        public void onZoomLevel()
        {
            realTimeMap.View.setZoomLevel = 15;
        }
        public async Task onLocation()
        {
            realTimeMap.View.setCenter = new RealTimeMap.Location()
            {
                latitude = await GetLargerArea(latdeg),
                longitude = await GetLargerArea(longdeg)
            };
        }
        public void onBounds()
        {
            realTimeMap.View.setBounds = new RealTimeMap.Bounds()
            {
                northEast = new RealTimeMap.Location() { latitude = 44.119016922388475, longitude = 25.5423343754357 },
                southWest = new RealTimeMap.Location() { latitude = 44.06574292386291, longitude = 25.67686807545283 }
            };
        }
        private async Task<Double> GetLargerArea(double obj)
        {
            double truncatedValue = Math.Truncate(obj * 100) / 100;
            return truncatedValue;
        }
    }
}
