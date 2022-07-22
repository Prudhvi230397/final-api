using AirLineMicroservices.Interface;
using AirLineMicroservices.Models;
using AirLineMicroservices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineMicroservices.Services
{
    public class AddInventoryImpl : IAddInventory
    {
        AirLineInventoryDBContext db;
        public AddInventoryImpl(AirLineInventoryDBContext _db)
        {
            db = _db;

        }
        public bool AddInventory(Schedule _schedule)
        {
            try
            {
                var from = _schedule.StartDateTime; // 25/8/2019
                var to = _schedule.EndDateTime; // 23/9/2019
                if (_schedule.Monday) {
                var allMondays = GetWeekdayInRange(from,to, DayOfWeek.Monday);
                    foreach(var day in allMondays)
                    UpdateDB(_schedule, day);
                }
                if (_schedule.Tuesday)
                {
                    var alldays = GetWeekdayInRange(from, to, DayOfWeek.Tuesday);
                    foreach (var day in alldays)
                        UpdateDB(_schedule, day);
                }
                if (_schedule.Wednesday)
                {
                    var alldays = GetWeekdayInRange(from, to, DayOfWeek.Wednesday);
                    foreach (var day in alldays)
                        UpdateDB(_schedule, day);
                }
                if (_schedule.Thursday)
                {
                    var alldays = GetWeekdayInRange(from, to, DayOfWeek.Thursday);
                    foreach (var day in alldays)
                        UpdateDB(_schedule, day);
                }
                if (_schedule.Friday)
                {
                    var alldays = GetWeekdayInRange(from, to, DayOfWeek.Friday);
                    foreach (var day in alldays)
                        UpdateDB(_schedule, day);
                }
                if (_schedule.Saturday)
                {
                    var alldays = GetWeekdayInRange(from, to, DayOfWeek.Saturday);
                    foreach (var day in alldays)
                        UpdateDB(_schedule, day);
                }
                if (_schedule.Sunday)
                {
                    var alldays = GetWeekdayInRange(from, to, DayOfWeek.Sunday);
                    foreach (var day in alldays)
                        UpdateDB(_schedule, day);
                }


                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void  UpdateDB(Schedule _schedule, DateTime date )
        {
            FlightSchedule schedule = new FlightSchedule();
            schedule.FlightNo = _schedule.FlightNo;
            schedule.AirlineId = _schedule.AirlineId;
            schedule.BoardingPlace = _schedule.BoardingPlace;
            schedule.Destination = _schedule.Destination;
            schedule.StartDateTime = date;
            schedule.EndDateTime = date;
            schedule.EconomySeats = _schedule.EconomySeats;
            schedule.BusinessClassSeats = _schedule.BusinessClassSeats;
            schedule.VacantEconomySeats = _schedule.EconomySeats;
            schedule.VacantBusinessSeats = _schedule.BusinessClassSeats;
            schedule.TicketCost = _schedule.TicketCost;
            schedule.ScheduledDaysId = "NA";
            schedule.InstrumentUsed = _schedule.InstrumentUsed;
            schedule.MealId = _schedule.MealId;
            schedule.NoOfRows = _schedule.NoOfRows;
            schedule.Travelstarttime = _schedule.travelstarttime;
            schedule.Travelendtime = _schedule.travelendtime;
            db.FlightSchedules.Add(schedule);
            db.SaveChanges();
        }
        public  List<DateTime> GetWeekdayInRange( DateTime from, DateTime to, DayOfWeek day)
        {
            const int daysInWeek = 7;
            var result = new List<DateTime>();
            var daysToAdd = ((int)day - (int)from.DayOfWeek + daysInWeek) % daysInWeek;

            do
            {
                from = from.AddDays(daysToAdd);
                result.Add(from);
                daysToAdd = daysInWeek;
            } while (from < to);

            return result;
        }
    }
}
