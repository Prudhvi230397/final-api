using BookingWebServices.Models;
using BookingWebServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.Interface
{
    public interface IBookFlight
    {
        Boolean UpdatePassengerDetails(BookingInformation bookingInformation,string pnr, string flightNo);
    }
}
