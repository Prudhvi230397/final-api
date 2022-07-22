using AirLineMicroservices.Interface;
using AirLineMicroservices.Models;
using AirLineMicroservices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineMicroservices.Services
{
    public class RegisterAirlineImpl : IRegisterAirline
    {
        AirLineInventoryDBContext db;
        
        public RegisterAirlineImpl(AirLineInventoryDBContext _db)
        {
            db = _db;
            
        }
        public bool RegisterAirline(RegisterAirLineServices _airlines)
        {
            try
            {
            AirLine airline = new AirLine();
            airline.AirlineName = _airlines.AirlineName;
            airline.AirlineLogo = Encoding.Unicode.GetBytes(_airlines.AirlineLogo);
            airline.ContactNo = _airlines.ContactNo;
            airline.Address = _airlines.Address;
            airline.IsBlocked = _airlines.IsBlocked;   
            db.AirLines.Add(airline);
            db.SaveChanges();
            return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
