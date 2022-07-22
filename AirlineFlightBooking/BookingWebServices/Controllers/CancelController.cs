using BookingWebServices.Interface;
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
    public class CancelController : ControllerBase
    {


        ICancelTicket cancelTicket;
        public CancelController(ICancelTicket _cancelTicket)
        {
            cancelTicket = _cancelTicket;
        }
        [HttpDelete]
        [Route("{pnr}")]
        public IActionResult getpnrDetails([FromRoute] string pnr)
        {
            if(cancelTicket.CancelTicket(pnr))
            return Ok("Ticket Cancelled");
            return BadRequest();
        }
    }
}
