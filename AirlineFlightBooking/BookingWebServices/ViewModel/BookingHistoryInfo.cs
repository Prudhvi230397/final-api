using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.ViewModel
{
    public class BookingHistoryInfo
    {
        public bool IsCancelled { get; set; }
        public string EmailId { get; set; }
        public string FlightNo { get; set; }
        public string Boarding { get; set; }
        public string Destination { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool IsRoundTrip { get; set; }
        //public DateTime RoundTripStartDateTime { get; set; }
        //public DateTime RoundTripEndDateTime { get; set; }
        //public string RoundTripFlightNo { get; set; }
        public string Pnr { get; set; }
        public string PassengerName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string SeatNo { get; set; }
        public string Meal { get; set; }
        public string NationalId { get; set; }
    }
}
