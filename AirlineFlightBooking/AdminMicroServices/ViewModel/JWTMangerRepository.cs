using AdminMicroServices.Interface;
using AdminMicroServices.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdminMicroServices.ViewModel
{
    public class JWTMangerRepository : IJWTMangerRepository
    {

        Dictionary<string, string> userRecords;

        private readonly IConfiguration configuration;

        private readonly AirLineBookingDBContext db;

        public JWTMangerRepository(IConfiguration _configuration, AirLineBookingDBContext _db)
        {
            configuration = _configuration;
            db = _db;
        }
        public Tokens Authenticate(LoginViewModel users,bool IsRegister)
        {
            if (IsRegister)
            {
                if (db.UserDetails.Any(x => x.UserName == users.UserName))
                {
                    return null;
                }

                UserDetail tbllogin = new UserDetail();
               
                tbllogin.UserName = users.UserName;
                tbllogin.Password = users.Password;
                db.UserDetails.Add(tbllogin);
                db.SaveChanges();
            }
            userRecords = db.UserDetails.ToList().ToDictionary(x => x.UserName, x => x.Password);

            string Admin = "N";
            if(db.UserDetails.Any(x => x.UserName == users.UserName && x.Password == users.Password && x.IsAdmin=="Y"))
            {
                Admin = "Y";
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            if (!userRecords.Any(x => x.Key == users.UserName && x.Value == users.Password))
            {
                return null;
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,users.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token), 
                UserRole = Admin
            };
        }
    }
}
