using BookingWebServices.Models;
using BookingWebServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.Interface
{
    public interface IBookingHistory
    {
        List<BookingHistoryInfo> BookingHistory(string email);
    }
}
