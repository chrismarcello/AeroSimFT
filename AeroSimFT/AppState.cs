using AeroSimFT.Pages;
using AeroSimFT.Pages.Airports;
using AeroSimFT.Views;

namespace AeroSimFT
{
    public static class AppState
    {
        public static MainWindow? MainWindow { get; set; }
        public static Home? IndexPage { get; set; }
        public static FlownFlights? FlownFlights { get; set; }
        public static RandomFlight? RandomFlight { get; set; }
        public static AirportWindow? AirportWindow { get; set; }
        public static AirportIndex? AirportIndex { get; set; }
        public static AirportDetails? AirportDetails { get; set; }

    }
}
