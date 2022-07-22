using System;
using System.Collections.Generic;

#nullable disable

namespace AirLineMicroservices.Models
{
    public partial class Discount
    {
        public int DiscountId { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountValue { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
