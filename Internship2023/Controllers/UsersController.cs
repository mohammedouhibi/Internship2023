using Internship2023_backend.Interfaces;
using Internship2023_backend.Models;
using Internship2023_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Internship2023_backend.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        readonly IUsersService us;
        readonly IJWTService jwtService;
        public UsersController(IUsersService us, IJWTService jwtService)
        {
            this.us = us;
            this.jwtService = jwtService;
        }

        [Route("register")]
        [HttpPost]
        public  string  RegisterUser(User user)
        {
            if (user == null)
            {
                return "User is null";
            }
            else
            {
                try
                {
                    var password = user.Password;
                    user.SetPassword(password);
                    us.Add(user);
                    us.Commit();
                    return "User created successfully" + user.VerifyPassword(password) + "hashed password :" +
                        user.Password;
                }
                catch (Exception ex)
                {
                    return "error: " + ex.StackTrace;
                }
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {
            var user = us.Get(u => u.Email.ToLower().Equals(request.Email));
            if (user.Email != request.Email)
            {
                return BadRequest("User not found.");
            }

            if (!user.VerifyPassword(request.Password))
            {
                return BadRequest("Wrong password.");
            }

            string token = jwtService.CreateToken(user);

            return Ok(token);
        }

        
        [Route("Cookie")]
        [HttpGet]
        [Authorize]
        public string GetCookie()
        {
            return "Cookie from the backend!";
        }


    }
}

