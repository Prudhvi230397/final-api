using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMicroServices.ViewModel
{
    public class IdentityTokenParameters
    {
        public string grant_type { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
    }
}
