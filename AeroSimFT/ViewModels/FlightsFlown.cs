using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSimFT.ViewModels
{
    public class FlightsFlown
    {
        private Int32 _flightId;
        private DateTime _datecreated;
        private string _aircraftName;
        private string _departAirport;
        private string _departAirportArea;
        private string _arrivalAirport;
        private string _arrivalAirportArea;
        private Int32 _distance;
        private TimeSpan _estFlightTime;
        private bool _crashed;
        private DateTime? _dateFlown;
        private bool _selected = false;

        public FlightsFlown() { }

        public FlightsFlown(int flightId, DateTime dateCreate, string aircraftName, string departAirport, string departAirportArea, string arrivalAirport, string arrivalAirportArea, int distance, TimeSpan estFlightTime, DateTime? dateFlown, bool crashed, bool selected)
        {
            FlightId = flightId;
            DateCreate = dateCreate;
            AircraftName = aircraftName;
            DepartAirport = departAirport;
            DepartAirportArea = departAirportArea;
            ArrivalAirport = arrivalAirport;
            ArrivalAirportArea = arrivalAirportArea;
            Distance = distance;
            EstFlightTime = estFlightTime;
            DateFlown = dateFlown;
            Crashed = crashed;
            Selected = selected;
        }

        public Int32 FlightId
        {
            get { return _flightId; }
            set { _flightId = value; }
        }
        public DateTime DateCreate
        {
            get { return _datecreated; }
            set { _datecreated = value; }
        }
        public string AircraftName
        {
            get { return _aircraftName; }
            set { _aircraftName = value; }
        }
        public string DepartAirport
        {
            get { return _departAirport; }
            set { _departAirport = value; }
        }
        public string DepartAirportArea
        {
            get { return _departAirportArea; }
            set { _departAirportArea = value; }
        }
        public string ArrivalAirport
        {
            get { return _arrivalAirport; }
            set { _arrivalAirport = value; }
        }
        public string ArrivalAirportArea
        {
            get { return _arrivalAirportArea; }
            set { _arrivalAirportArea = value; }
        }
        public Int32 Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }
        public TimeSpan EstFlightTime
        {
            get { return _estFlightTime; }
            set { _estFlightTime = value; }
        }
        public DateTime? DateFlown
        {
            get { return _dateFlown; }
            set { _dateFlown = value; }
        }
        public bool Crashed
        {
            get { return _crashed; }
            set { _crashed = value; }
        }
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
    }
}