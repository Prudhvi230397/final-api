using AirLineMicroservices.Interface;
using AirLineMicroservices.Models;
using AirLineMicroservices.Services;
using AirLineMicroservices.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineMicroservices.Controllers
{
    
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    //[Authorize]
    public class AirlineController : ControllerBase
    {
        IRegisterAirline registerAirline;
        IAddInventory addInventory;
        AirLineInventoryDBContext db;
        public AirlineController(IAddInventory _addInventory, IRegisterAirline _registerAirline, AirLineInventoryDBContext _db)
        {

            registerAirline = _registerAirline;
            addInventory = _addInventory;
            db = _db;
        }
       
        [HttpPost("register")]
        public IActionResult RegisterAirline(RegisterAirLineServices _airlines)
        {
            if (registerAirline.RegisterAirline(_airlines))
            return Ok("Airline Registered Successfully");
            return BadRequest();
        }

        [HttpPost("inventory/add")]
        public IActionResult AddInventory(Schedule _schedule )
        {
            
            if(addInventory.AddInventory(_schedule))
            return Ok("Airline Inventory Added Successfully");
            return BadRequest();
        }

        [HttpGet("getAirlineData")]

        public IEnumerable<AirlineDetails> getAirlineNameData()
        {
            List<AirlineDetails> airlineList = new List<AirlineDetails>();
            foreach(var res in db.AirLines)
            {
                AirlineDetails airline = new AirlineDetails();
                airline.AirlineId = res.AirlineId;
                airline.AirlineName = res.AirlineName;
                airlineList.Add(airline);
            }
            return airlineList;
        }

        [HttpGet("getAirlineDetails")]

        public IEnumerable<AirLine> getAirlineDetails()
        {
            //List<AirLine> airlineList = new List<AirLine>();
            
            return db.AirLines.ToList();
        }

        [HttpPut("Block")]
        public IActionResult BlockUnblockAirline(BlockUnBlockAirline blockUnBlockAirline )
        {
            if (db.AirLines.Any(x => x.AirlineId == blockUnBlockAirline.AirlineId))
            {
                var data = db.AirLines.Where(x => x.AirlineId == blockUnBlockAirline.AirlineId).FirstOrDefault();
                data.IsBlocked = blockUnBlockAirline.IsBlocked;
                db.AirLines.Update(data);
                db.SaveChanges();
                return Ok("Record updated Successfully");
            }
            return BadRequest();
        }
    }
}
