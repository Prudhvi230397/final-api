using System;
using System.Collections.Generic;

#nullable disable

namespace SearchWebServices.Models
{
    public partial class AirLine
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public byte[] AirlineLogo { get; set; }
        public decimal? ContactNo { get; set; }
        public string Address { get; set; }
        public bool? IsBlocked { get; set; }
    }
}
