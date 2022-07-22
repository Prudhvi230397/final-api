using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchWebServices.Interface;
using SearchWebServices.Models;
using SearchWebServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchWebServices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        ISearchFlights searchFlight;
        public SearchController(ISearchFlights _searchFlight)
        {
            searchFlight = _searchFlight;
        }

        [HttpPost]
        public SearchFlightResults FindFlight(SearchFlightDetails flightDetails)
        {
            try
            {
                return searchFlight.SearchFlights(flightDetails);
            }
            catch(Exception ex)
            {
                throw  ex;
            }
        }
    }
}
