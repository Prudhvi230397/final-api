using BookingWebServices.ViewModel;
using MassTransit.KafkaIntegration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.Services
{
    public class UpdateInventoryTable
    {
        private ITopicProducer<FlightDetails> _topicProducer;
        public UpdateInventoryTable()
        {

        }
        public UpdateInventoryTable(ITopicProducer<FlightDetails> topicProducer)
        {
            _topicProducer = topicProducer;
        }

       
        public async void UpdateAirlineInventory(BookingInformation Bookinginfo, string flightNo)
        {
            FlightDetails flightDetails = new FlightDetails();
            flightDetails.NoOfSeats = Convert.ToInt32(Bookinginfo.NoOfSeats);
            flightDetails.Boarding = Bookinginfo.Boarding;
            flightDetails.Destination = Bookinginfo.Destination;
            flightDetails.StartDateTime = Bookinginfo.StartDateTime;
            //flightDetails.EndDateTime = Bookinginfo.EndDateTime;
            flightDetails.EndDateTime = DateTime.Now;
            flightDetails.IsRoundTrip = Bookinginfo.IsRoundTrip;
           // flightDetails.IsRoundTrip = Convert.ToBoolean(Bookinginfo.IsRoundTrip);
            flightDetails.RoundTripStartDateTime = Bookinginfo.RoundTripStartDateTime;
            //flightDetails.RoundTripEndDateTime = Bookinginfo.RoundTripEndDateTime;
            flightDetails.RoundTripEndDateTime = DateTime.Now;
            flightDetails.RoundTripFlightNo = Bookinginfo.RoundTripFlightNo;

            await _topicProducer.Produce(flightDetails);
            //return Ok("Sucess");
        }
    }
}
