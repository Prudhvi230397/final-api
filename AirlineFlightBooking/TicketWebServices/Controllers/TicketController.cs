using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketWebServices.Interface;
using TicketWebServices.Models;

namespace TicketWebServices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public class TicketController : ControllerBase
    {
        IPNRDetails iPNRDetails;
        public TicketController(IPNRDetails _iPNRDetails)
        {
            iPNRDetails = _iPNRDetails;
        }
        [HttpGet]
        [Route("{pnr}")]
        public IEnumerable<BookingDetail> getpnrDetails([FromRoute] string pnr)
        {
            
            return iPNRDetails.FindPNR(pnr);
            
        }
    }

}
