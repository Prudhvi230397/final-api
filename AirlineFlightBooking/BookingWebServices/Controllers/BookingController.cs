using BookingWebServices.Interface;
using BookingWebServices.Models;
using BookingWebServices.Services;
using BookingWebServices.ViewModel;
using MassTransit.KafkaIntegration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookFlight bookFlight;

        private ITopicProducer<FlightDetails> topicProducer;
        public BookingController(IBookFlight _bookFlight, ITopicProducer<FlightDetails> _topicProducer)
        {
            bookFlight = _bookFlight;
            topicProducer = _topicProducer;
        }
        [HttpPost]
        [Route("{flightNo}")]
        public async  Task<IActionResult> BookTicket([FromRoute] string flightNo, BookingInformation Bookinginfo)
        {
           
            Random random = new Random();
            int pnr = random.Next(1,90000000);
            string msg = "Ticket Booked Successfully " ;
            if (bookFlight.UpdatePassengerDetails(Bookinginfo, Convert.ToString(pnr), Convert.ToString(flightNo)))
            {
                FlightDetails flightDetails = new FlightDetails();
                flightDetails.NoOfSeats = Convert.ToInt32(Bookinginfo.NoOfSeats);
                flightDetails.FlightId = Convert.ToInt32( Bookinginfo.flightId);
                flightDetails.RoundFlightId = Convert.ToInt32(Bookinginfo.rflightId);
                flightDetails.IsRoundTrip = Bookinginfo.IsRoundTrip;

                // flightDetails.Boarding = Bookinginfo.Boarding;
                // flightDetails.Destination = Bookinginfo.Destination;
                // flightDetails.StartDateTime = Bookinginfo.StartDateTime;
                // //flightDetails.EndDateTime = Bookinginfo.EndDateTime;
                // //flightDetails.IsRoundTrip = Convert.ToBoolean(Bookinginfo.IsRoundTrip);
                // flightDetails.IsRoundTrip = Bookinginfo.IsRoundTrip;
                // flightDetails.RoundTripStartDateTime = Bookinginfo.RoundTripStartDateTime;
                //// flightDetails.RoundTripEndDateTime = Bookinginfo.RoundTripEndDateTime;
                // flightDetails.RoundTripFlightNo = Bookinginfo.RoundTripFlightNo;

               // await topicProducer.Produce(flightDetails);
                return Ok(msg);
            }
            else
                return Ok("error in Booking tickets");
        }
    }
}
