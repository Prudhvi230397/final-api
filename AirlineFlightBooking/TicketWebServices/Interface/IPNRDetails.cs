using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketWebServices.Models;

namespace TicketWebServices.Interface
{
    public interface IPNRDetails
    {
        List<BookingDetail> FindPNR(string pnr);
    }
}
