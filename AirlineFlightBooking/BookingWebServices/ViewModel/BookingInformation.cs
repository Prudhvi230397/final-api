using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.ViewModel
{
    public class BookingInformation
    {
        public string EmailId { get; set; }
        public int ticketCost { get; set; }
        public int rticketCost { get; set; }
        public int totalPrice { get; set; }

        public string NoOfSeats { get; set; }
        public string FlightNo { get; set; }
        public string Boarding { get; set; }
        public string Destination { get; set; }
        public DateTime StartDateTime { get; set; }
       
        public string EndDateTime { get; set; }
        public bool IsRoundTrip { get; set; }
      
        public DateTime RoundTripStartDateTime { get; set; }
      
        public string RoundTripEndDateTime { get; set; }
        public string RoundTripFlightNo { get; set; }

        public int flightId { get; set; }
        public int rflightId { get; set; }

        public List<Passenger> passenger { get; set; }
    }
}
