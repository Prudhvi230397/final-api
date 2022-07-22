using System;
using System.Collections.Generic;

#nullable disable

namespace AirLineMicroservices.Models
{
    public partial class DiscountViewModel
    {
        
        public string DiscountCode { get; set; }
        public int DiscountValue { get; set; }
        public string ExpiryDate { get; set; }
    }
}
