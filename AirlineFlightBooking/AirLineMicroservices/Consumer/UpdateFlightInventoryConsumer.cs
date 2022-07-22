using AirLineMicroservices.Models;
using AirLineMicroservices.ViewModel;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineMicroservices.Consumer
{
    public class UpdateFlightInventoryConsumer : IConsumer<FlightDetails>
    {
        AirLineInventoryDBContext db;
        public UpdateFlightInventoryConsumer(AirLineInventoryDBContext _db)
        {
            db = _db;
        }
        public Task Consume(ConsumeContext<FlightDetails> context)
        {
            var message = context.Message;

            if(db.FlightSchedules.Any(x=> x.FlightId==message.FlightId))
            {
                var data = db.FlightSchedules.Where(x => x.FlightId == message.FlightId).FirstOrDefault();
                data.VacantEconomySeats = data.VacantEconomySeats - message.NoOfSeats;
                db.FlightSchedules.Update(data);
                db.SaveChanges();
            }

            if (message.IsRoundTrip)
            {
                if (db.FlightSchedules.Any(x => x.FlightId == message.RoundFlightId))
                {
                    var data = db.FlightSchedules.Where(x => x.FlightId == message.RoundFlightId).FirstOrDefault();
                    data.VacantEconomySeats = data.VacantEconomySeats - message.NoOfSeats;
                    db.FlightSchedules.Update(data);
                    db.SaveChanges();
                }
            }
                
                //if (db.FlightSchedules.Any(x => x.FlightNo == message.FlightNo))
                //{
                //    var data = db.FlightSchedules.Where(x => x.FlightNo == message.FlightNo
                //    && x.BoardingPlace == message.Boarding && x.Destination == message.Destination
                //    && x.StartDateTime == message.StartDateTime && x.EndDateTime == message.EndDateTime).FirstOrDefault();
                //    data.VacantEconomySeats = data.VacantEconomySeats - message.NoOfSeats;
                //    db.FlightSchedules.Update(data);
                //    db.SaveChanges();
                //    if (message.IsRoundTrip)
                //    {
                //        var data2 = db.FlightSchedules.Where(x => x.FlightNo == message.RoundTripFlightNo
                //        && x.BoardingPlace == message.Destination && x.Destination == message.Boarding
                //        && x.StartDateTime == message.RoundTripStartDateTime && x.EndDateTime == message.RoundTripEndDateTime).FirstOrDefault();
                //        data2.VacantEconomySeats = data2.VacantEconomySeats - message.NoOfSeats;
                //        db.FlightSchedules.Update(data2);
                //        db.SaveChanges();
                //    }
                //}
                return Task.CompletedTask;
        }
    }
}
