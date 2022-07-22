using AdminMicroServices.Interface;
using AdminMicroServices.Models;
using AdminMicroServices.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMicroServices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
      
        private readonly IJWTMangerRepository iJWTMangerRepository;
        AirLineBookingDBContext db;
        public LoginController( IJWTMangerRepository _iJWTMangerRepository, AirLineBookingDBContext _db)
        {
           
            iJWTMangerRepository = _iJWTMangerRepository;
            db = _db;
        }
        //For Identity server start 
        //Uncomment if using identity server
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        //{

        //    var userRecords = db.UserDetails.ToList().ToDictionary(x => x.UserName, x => x.Password);

        //    string Admin = "N";
        //    if (db.UserDetails.Any(x => x.UserName == loginViewModel.UserName && x.Password == loginViewModel.Password && x.IsAdmin == "Y"))
        //    {
        //        Admin = "Y";
        //    }



        //    if (!userRecords.Any(x => x.Key == loginViewModel.UserName && x.Value == loginViewModel.Password))
        //    {
        //        return Ok("Invalid User Credentials");
        //    }

        //    Tokens token = new Tokens();
        //    IdentityServerToken identityServerToken = new IdentityServerToken();
        //    token.Token = await identityServerToken.GetApiToken();
        //    token.UserRole = Admin;


        //    return Ok(token);
        //}



        //[HttpPost("Register")]
        //public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        //{
        //    if (db.UserDetails.Any(x => x.UserName == loginViewModel.UserName))
        //    {
        //        return Ok("User Credentials Already Exists ");
        //    }

        //    UserDetail tbllogin = new UserDetail();
        //    tbllogin.UserName = loginViewModel.UserName;
        //    tbllogin.Password = loginViewModel.Password;
        //    db.UserDetails.Add(tbllogin);
        //    db.SaveChanges();
        //    var userRecords = db.UserDetails.ToList().ToDictionary(x => x.UserName, x => x.Password);

        //    string Admin = "N";
        //    if (db.UserDetails.Any(x => x.UserName == loginViewModel.UserName && x.Password == loginViewModel.Password && x.IsAdmin == "Y"))
        //    {
        //        Admin = "Y";
        //    }

        //    Tokens token = new Tokens();
        //    IdentityServerToken identityServerToken = new IdentityServerToken();
        //    token.Token = await identityServerToken.GetApiToken();
        //    token.UserRole = Admin;

        //    return Ok(token);

        //}
        //For Identity server ends


        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {

            var token = iJWTMangerRepository.Authenticate(loginViewModel, false);

            if (token == null)
            {
                return Ok("Invalid User Credentials");
            }
            return Ok(token);
        }



        [HttpPost("Register")]
        public IActionResult Register(LoginViewModel loginViewModel)
        {
            var token = iJWTMangerRepository.Authenticate(loginViewModel, true);
            if (token == null)
            {
                return Ok("User Credentials Already Exists ");
            }
            return Ok(token);
        }
    }
}
