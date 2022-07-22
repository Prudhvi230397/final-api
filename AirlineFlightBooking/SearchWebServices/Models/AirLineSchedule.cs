using System;
using System.Collections.Generic;

#nullable disable

namespace SearchWebServices.Models
{
    public partial class AirLineSchedule
    {
        public string FlightNo { get; set; }
        public string Airline { get; set; }
        public string BoardingPlace { get; set; }
        public string Destination { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string ScheduledDays { get; set; }
        public string InstrumentUsed { get; set; }
        public int BusinessClassSeats { get; set; }
        public int EconomySeats { get; set; }
        public decimal TicketCost { get; set; }
        public int? NoOfRows { get; set; }
        public string Meal { get; set; }
        public bool? IsRoundTrip { get; set; }
    }
}
