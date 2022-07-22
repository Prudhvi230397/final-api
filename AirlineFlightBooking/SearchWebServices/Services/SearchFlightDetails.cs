using SearchWebServices.Interface;
using SearchWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchWebServices.Services
{
    public class SearchFlightDetails
    { 
        public string BoardingPlace { get; set; }
        public string Destination { get; set; }
        public DateTime StartDateTime { get; set; }
       // public DateTime EndDateTime { get; set; }
        public bool IsRoundTrip { get; set; }
        public DateTime RoundStartDateTime { get; set; }
       // public DateTime RoundEndDateTime { get; set; }

    }
}
