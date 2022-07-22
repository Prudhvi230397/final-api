using BookingWebServices.Interface;
using BookingWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.Services
{
    public class CancelTicketImpl : ICancelTicket
    {
        AirLineBookingDBContext db;
        public CancelTicketImpl(AirLineBookingDBContext _db)
        {
            db = _db;
        }
        public bool CancelTicket(string pnr)
        {
            if (db.BookingDetails.Any(x => x.Pnr == pnr))
            {
                var data = db.BookingDetails.Where(x => x.Pnr == pnr);
                foreach (BookingDetail bookingDetail in data)
                {
                    bookingDetail.IsCancelled = true;
                    db.BookingDetails.Update(bookingDetail);
                }
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
