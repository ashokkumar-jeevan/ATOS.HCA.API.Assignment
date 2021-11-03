using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;

using HCA.Users.BO;
using HCA.UsersClient;
using HCA.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HCA.LabReports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        #region Login 
        
        private AppSettings appSettings;

        public UsersController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult ValidateUser([FromBody] UsersBO usersBO)
        {
            try
            {
               UserClient usersClient = new UserClient(appSettings);
                string password = usersBO.Password;
                usersBO = usersClient.ValidateUser(usersBO.UserName, usersBO.Password);
                // userDataUI.IsValidUser = true;
                if (usersBO != null && usersBO.IsValidUser)
                {
                   
                    var tokenHandler = new JwtSecurityTokenHandler();
                    //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                    var key = Encoding.ASCII.GetBytes("needtogetthisfromenvironment");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, usersBO.UserName + usersBO.UserId.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    usersBO.Token = tokenHandler.WriteToken(token);


                    return Ok(usersBO);
                }
                else
                {
                    return BadRequest(usersBO);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }       


        #endregion


      
    }
}
