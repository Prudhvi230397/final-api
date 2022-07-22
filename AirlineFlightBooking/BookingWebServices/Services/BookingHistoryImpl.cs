using BookingWebServices.Interface;
using BookingWebServices.Models;
using BookingWebServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.Services
{
    public class BookingHistoryImpl : IBookingHistory
    {
        AirLineBookingDBContext db;
        public BookingHistoryImpl(AirLineBookingDBContext _db)
        {
            db = _db;
        }
        public List<BookingHistoryInfo> BookingHistory(string email)
        {
            //var data = db.PassengerDetails.Where(x => x.EmailId == email);
            //return data.ToList();

            var data1 = from b in db.BookingDetails
                        from p in db.PassengerDetails
                        where (b.EmailId==email && b.Pnr==p.Pnr)
                        select new { b.BookingId,b.Boarding,b.Destination,b.EndDateTime
                        ,b.StartDateTime,b.Pnr,b.NoOfseats,b.IsCancelled,b.IsRoundTrip,
                        p.PassengerName,p.SeatNo,p.Gender,p.NationalId,p.Age,p.Meal,b.FlightNo
                        };
            List<BookingHistoryInfo> BList = new List<BookingHistoryInfo>();
            foreach (var res in data1)
            {
                BookingHistoryInfo BInfo = new BookingHistoryInfo();
                BInfo.EmailId = email;
                BInfo.Boarding = res.Boarding;
                BInfo.FlightNo = res.FlightNo;
                BInfo.Destination = res.Destination;
                BInfo.StartDateTime = res.StartDateTime;
                BInfo.EndDateTime = res.EndDateTime;
                BInfo.IsCancelled = res.IsCancelled;
                BInfo.IsRoundTrip = res.IsRoundTrip;
                //BInfo.RoundTripStartDateTime = res.RoundTripStartDateTime;
                //BInfo.RoundTripEndDateTime = res.RoundTripEndDateTime;
                //BInfo.RoundTripFlightNo = res.RoundTripFlightNo;
                BInfo.PassengerName = res.PassengerName;
                BInfo.Age = res.Age;
                BInfo.Gender = res.Gender;
                BInfo.NationalId = res.NationalId;
                BInfo.Meal = res.Meal;
                BInfo.SeatNo = res.SeatNo;
                BInfo.Pnr = res.Pnr;
                BList.Add(BInfo);
            }
            return BList;
;        }
    }
}
