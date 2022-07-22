using AirLineMicroservices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineMicroservices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    //[ApiController]
    public class DiscountController : ControllerBase
    {
        AirLineInventoryDBContext db;
        public DiscountController(AirLineInventoryDBContext _db)
        {
            db = _db;
        }
        [HttpPost("Add")]
        public IActionResult AddDiscount([FromBody]DiscountViewModel discountViewModel)
        {
            Discount discount = new Discount();
            discount.DiscountCode = discountViewModel.DiscountCode;
            discount.DiscountValue = discountViewModel.DiscountValue;
            discount.ExpiryDate = Convert.ToDateTime(discountViewModel.ExpiryDate);

            db.Discounts.Add(discount);
            db.SaveChanges();
            return Ok("Discount Added Successfully");

        }

        [HttpGet("getDiscountDetails")]

        public IEnumerable<Discount> getDiscountDetails()
        {
            return db.Discounts.ToList();
        }

        [HttpGet]
        [Route("getDiscountValue/{DiscountCode}")]
        public int getDiscountValue([FromRoute] string DiscountCode)
        {
            int value = 0;
            if (db.Discounts.Any(x => x.DiscountCode == DiscountCode))
            {
                var data = db.Discounts.Where(x => x.DiscountCode == DiscountCode).FirstOrDefault();
                value= (int)data.DiscountValue;
                return value;
            }
            return value;

        }

        [HttpDelete]
        [Route("Delete/{DiscountId}")]
        public IActionResult DeleteDiscount([FromRoute] string DiscountId)
        {
            if (db.Discounts.Any(x => x.DiscountId == Convert.ToInt32(DiscountId)))
            {
                var data = db.Discounts.Where(x => x.DiscountId == Convert.ToInt32(DiscountId)).FirstOrDefault();
                db.Discounts.Remove(data);
                db.SaveChanges();
                return Ok("Record Deleted Successfully");
            }
            return BadRequest();
        }
    }
}
