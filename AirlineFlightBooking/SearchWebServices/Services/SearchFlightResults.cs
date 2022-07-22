using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchWebServices.Services
{
    public class SearchFlightResults
    {
       public List<Onward> Onward { get; set; }
        public List<RoundTrip> RoundTrip { get; set; }

    }
    public class Onward
    {
        public string AirlineName { get; set; }
        public byte[] AirlineLogo { get; set; }
        public string FlightNo { get; set; }
        public decimal TicketCost { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public int FlightId { get; set; }

    }
    public class RoundTrip
    {
        public string AirlineName { get; set; }
        public byte[] AirlineLogo { get; set; }
        public string FlightNo { get; set; }
        public decimal TicketCost { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public int FlightId { get; set; }

    }
}
