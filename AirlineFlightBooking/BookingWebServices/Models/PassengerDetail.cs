using System;
using System.Collections.Generic;

#nullable disable

namespace BookingWebServices.Models
{
    public partial class PassengerDetail
    {
        public int PassengerId { get; set; }
        public int BookingId { get; set; }
        public string Pnr { get; set; }
        public string PassengerName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string SeatNo { get; set; }
        public string Meal { get; set; }
        public string NationalId { get; set; }
    }
}
