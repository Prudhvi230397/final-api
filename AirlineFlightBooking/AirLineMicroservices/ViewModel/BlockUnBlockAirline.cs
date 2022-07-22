using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineMicroservices.ViewModel
{
    public class BlockUnBlockAirline
    {
        public int AirlineId { get; set; }

        public bool IsBlocked { get; set; }
    }
}
