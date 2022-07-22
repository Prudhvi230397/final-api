using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.Interface
{
    public interface ICancelTicket
    {
        Boolean CancelTicket(string pnr);
    }
}
