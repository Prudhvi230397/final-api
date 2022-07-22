using BookingWebServices.Interface;
using BookingWebServices.Models;
using BookingWebServices.ViewModel;
using MassTransit.KafkaIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.Services
{
    public class BookFlightImpl : IBookFlight
    {
        AirLineBookingDBContext db;
        
        public BookFlightImpl(AirLineBookingDBContext _db, ITopicProducer<FlightDetails> _topicProducer)
        {
            db = _db;
           
        }
        public bool UpdatePassengerDetails(BookingInformation Bookinginfo, string pnr, string flightNo)
        {
            try
            {
                Random random = new Random();
                int rpnr = random.Next(1, 90000000);

                    BookingDetail booking = new BookingDetail();
                    booking.FlightNo = flightNo;
                    booking.NoOfseats =Convert.ToInt32( Bookinginfo.NoOfSeats);
                    booking.EmailId = Bookinginfo.EmailId;
                    booking.StartDateTime = Bookinginfo.StartDateTime;
                    booking.EndDateTime = DateTime.Now;
                   
                    booking.Destination = Bookinginfo.Destination;
                    booking.Boarding = Bookinginfo.Boarding;
                    booking.IsRoundTrip = Bookinginfo.IsRoundTrip;
                    booking.IsCancelled = false;
                    booking.Pnr = pnr;
                    booking.TicketCost = Bookinginfo.ticketCost;
                    booking.TotalCost = Bookinginfo.totalPrice;
                    //booking.RoundPnr = Convert.ToString(rpnr);
                     foreach (var passenger in Bookinginfo.passenger)
                    {
                        PassengerDetail passengerDetail = new PassengerDetail();
                        passengerDetail.Age = Convert.ToInt32(passenger.Age);
                        passengerDetail.Gender = passenger.Gender;
                        passengerDetail.PassengerName = passenger.PassengerName;
                        passengerDetail.SeatNo = passenger.SeatNo;
                        passengerDetail.Meal = passenger.Meal;
                        passengerDetail.NationalId = passenger.NationalId;
                        passengerDetail.Pnr = pnr;
                        db.PassengerDetails.Add(passengerDetail);
                        db.SaveChanges();
                }

                //    if (Bookinginfo.IsRoundTrip)
                //    {
                //        booking.RoundTripStartDateTime = Bookinginfo.RoundTripStartDateTime;
                //       // booking.RoundTripEndDateTime = Bookinginfo.RoundTripEndDateTime;
                //        booking.RoundTripEndDateTime = DateTime.Now;
                //        booking.RoundTripFlightNo = Bookinginfo.RoundTripFlightNo;

                //    foreach (var passenger in Bookinginfo.passenger)
                //    {
                //        PassengerDetail passengerDetail = new PassengerDetail();
                //        passengerDetail.Age = Convert.ToInt32(passenger.Age);
                //        passengerDetail.Gender = passenger.Gender;
                //        passengerDetail.PassengerName = passenger.PassengerName;
                //        passengerDetail.SeatNo = passenger.rseatNo;
                //        passengerDetail.Meal = passenger.Meal;
                //        passengerDetail.NationalId = passenger.NationalId;
                //        passengerDetail.Pnr = Convert.ToString(rpnr);
                //        db.PassengerDetails.Add(passengerDetail);
                //        db.SaveChanges();
                //    }

                //}

                db.BookingDetails.Add(booking);
                    db.SaveChanges();

                BookingDetail booking1 = new BookingDetail();
                if (Bookinginfo.IsRoundTrip)
                {

                    booking1.FlightNo = Bookinginfo.RoundTripFlightNo;
                    booking1.NoOfseats = Convert.ToInt32(Bookinginfo.NoOfSeats);
                    booking1.EmailId = Bookinginfo.EmailId;
                    booking1.StartDateTime = Bookinginfo.RoundTripStartDateTime;
                    booking1.EndDateTime = DateTime.Now;
                    booking1.Destination = Bookinginfo.Boarding;
                    booking1.Boarding = Bookinginfo.Destination;
                    booking1.IsRoundTrip = Bookinginfo.IsRoundTrip;
                    booking1.IsCancelled = false;
                    booking1.Pnr = Convert.ToString(rpnr);
                    booking1.TicketCost = Bookinginfo.rticketCost;
                    booking1.TotalCost = Bookinginfo.totalPrice;
                   
                    foreach (var passenger in Bookinginfo.passenger)
                    {
                        PassengerDetail passengerDetail = new PassengerDetail();
                        passengerDetail.Age = Convert.ToInt32(passenger.Age);
                        passengerDetail.Gender = passenger.Gender;
                        passengerDetail.PassengerName = passenger.PassengerName;
                        passengerDetail.SeatNo = passenger.rseatNo;
                        passengerDetail.Meal = passenger.Meal;
                        passengerDetail.NationalId = passenger.NationalId;
                        passengerDetail.Pnr = Convert.ToString(rpnr);
                        db.PassengerDetails.Add(passengerDetail);
                        db.SaveChanges();
                    }
                    db.BookingDetails.Add(booking1);
                    db.SaveChanges();
                }
               

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
           
        }
    }
}
