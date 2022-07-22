using AirLineMicroservices.Services;
using AirLineMicroservices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineMicroservices.Interface
{
    public interface IRegisterAirline
    {
        Boolean RegisterAirline(RegisterAirLineServices _airlines);
    }
}
