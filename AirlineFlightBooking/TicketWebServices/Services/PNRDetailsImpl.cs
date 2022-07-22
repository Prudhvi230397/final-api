using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketWebServices.Interface;
using TicketWebServices.Models;

namespace TicketWebServices.Services
{
    public class PNRDetailsImpl : IPNRDetails
    {
        AirLineBookingDBContext db;
        public PNRDetailsImpl(AirLineBookingDBContext _db)
        {
            db = _db;
        }
        public List<BookingDetail> FindPNR(string pnr)
        {
            var data = db.BookingDetails.Where(x => x.Pnr == pnr);
            return data.ToList();
        }
    }
}
