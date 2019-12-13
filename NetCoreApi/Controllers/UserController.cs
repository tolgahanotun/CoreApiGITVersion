using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreApiGITVersion.Interfaces.Service;
using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiGITVersion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
 
        public UserController(IUserService userService)
        {
            this.userService = userService; 
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            IEnumerable<Claim> claims = User.Claims;

            string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;

            GenericResponse<TUser> userResponse = userService.GetUserById(int.Parse(userId));

            if (userResponse.Success)
            {
                return Ok(userResponse.Object);
            }
            else
            {
                return BadRequest(userResponse.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        public IActionResult AddUser(TUser userResource)
        { 

            GenericResponse<TUser> userResponse = userService.AddUser(userResource);

            if (userResponse.Success)
            {
                return Ok(userResponse.Object);
            }
            else
            {
                return BadRequest(userResponse.Message);
            }
        }
    }

}