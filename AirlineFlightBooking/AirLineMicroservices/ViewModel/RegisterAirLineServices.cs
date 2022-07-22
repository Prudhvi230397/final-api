using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineMicroservices.ViewModel
{
    public class RegisterAirLineServices
    {
        public string AirlineName { get; set; }
        public string AirlineLogo { get; set; }
        public decimal ContactNo { get; set; }
        public string Address { get; set; }
        public bool? IsBlocked { get; set; }
    }
}
