using NPOI.SS.Formula.Functions;
using SearchWebServices.Interface;
using SearchWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchWebServices.Services
{
    public class SearchFlightImpl : ISearchFlights
    {

        AirLineInventoryDBContext db;
        public SearchFlightImpl(AirLineInventoryDBContext _db)
        {
            db = _db;
        }

        public SearchFlightResults SearchFlights(SearchFlightDetails searchFlight)
        {
            //var data = db.AirLineSchedules.Where(x => x.BoardingPlace == searchFlight.BoardingPlace && x.Destination == searchFlight.Destination && x.StartDateTime == searchFlight.StartDateTime && x.EndDateTime == searchFlight.EndDateTime && x.IsRoundTrip == searchFlight.IsRoundTrip);
            // return data.ToList();

            var data1 = from s in db.FlightSchedules
                        from a in db.AirLines
                        where (s.AirlineId == a.AirlineId && s.BoardingPlace == searchFlight.BoardingPlace
                             && s.Destination == searchFlight.Destination && s.StartDateTime == searchFlight.StartDateTime
                             && a.IsBlocked == false)
                             // && s.EndDateTime == searchFlight.EndDateTime && a.IsBlocked == false)
                        select new { a.AirlineName, a.AirlineLogo, s.BoardingPlace, s.Destination, s.StartDateTime,
                            s.EndDateTime, s.FlightNo, s.TicketCost ,s.Travelstarttime ,s.Travelendtime,s.FlightId};
            SearchFlightResults searchFlightResults = new SearchFlightResults();
           
             List<Onward> OnwardList = new List<Onward>();
            List<RoundTrip> RoundTripList = new List<RoundTrip>();
            foreach(var results in data1)
            {
                Onward searchResults = new Onward();
                searchResults.AirlineName= results.AirlineName;
                searchResults.AirlineLogo = results.AirlineLogo;
                searchResults.FlightNo = results.FlightNo;
                searchResults.TicketCost = results.TicketCost;
                searchResults.StartDateTime = results.Travelstarttime;
                searchResults.EndDateTime = results.Travelendtime;
                searchResults.FlightId = results.FlightId;

                OnwardList.Add(searchResults);
            }
            if (searchFlight.IsRoundTrip) {
                var data2 = from s in db.FlightSchedules
                            from a in db.AirLines
                            where (s.AirlineId == a.AirlineId && s.BoardingPlace == searchFlight.Destination
                                 && s.Destination == searchFlight.BoardingPlace && s.StartDateTime == searchFlight.RoundStartDateTime
                                 && a.IsBlocked == false)
                                 // && s.EndDateTime == searchFlight.RoundEndDateTime && a.IsBlocked == false)
                            select new { a.AirlineName, a.AirlineLogo, s.BoardingPlace, s.Destination,
                                s.StartDateTime, s.EndDateTime, s.FlightNo, s.TicketCost,s.Travelstarttime,s.Travelendtime,s.VacantEconomySeats,
                                s.FlightId
                            };
                
                foreach (var results in data2)
                {
                    RoundTrip searchResults = new RoundTrip();
                    searchResults.AirlineName = results.AirlineName;
                    searchResults.AirlineLogo = results.AirlineLogo;
                    searchResults.FlightNo = results.FlightNo;
                    searchResults.TicketCost = results.TicketCost;
                    searchResults.StartDateTime = results.Travelstarttime;
                    searchResults.EndDateTime = results.Travelendtime;
                    searchResults.FlightId = results.FlightId;
                    RoundTripList.Add(searchResults);
                }
            }
            searchFlightResults.Onward = OnwardList;
            searchFlightResults.RoundTrip = RoundTripList;
            return searchFlightResults;
        }
    }
}
