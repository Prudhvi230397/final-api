using System;
using System.Collections.Generic;

#nullable disable

namespace AdminMicroServices.Models
{
    public partial class BookingDetail
    {
        public int BookingId { get; set; }
        public string Pnr { get; set; }
        public int NoOfseats { get; set; }
        public string EmailId { get; set; }
        public bool IsCancelled { get; set; }
        public string FlightNo { get; set; }
        public string Boarding { get; set; }
        public string Destination { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool IsRoundTrip { get; set; }
        public decimal? TicketCost { get; set; }
        public decimal? TotalCost { get; set; }
    }
}
