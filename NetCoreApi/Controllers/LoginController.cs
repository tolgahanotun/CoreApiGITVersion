using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Interfaces.Service;
using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using CoreApiGITVersion.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiGITVersion.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

      

        [HttpPost]
        public IActionResult Accesstoken(TUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Check your Information");
            }
            else
            {
                GenericResponse<AccessToken> accessTokenResponse = authenticationService.CreateAccessToken(user.UserName,user.Password);

                if (accessTokenResponse.Success)
                {
                    return Ok(accessTokenResponse.Object);
                }
                else
                {
                    return BadRequest(accessTokenResponse.Message);
                }
            }
        }
        

        [HttpPost]
        public IActionResult RefreshToken(AccessToken tokenResource)
        {
            GenericResponse<AccessToken> accessTokenResponse = authenticationService.CreateAccessTokenByRefreshToken(tokenResource.RefreshToken);

            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.Object);
            }
            else
            {
                return BadRequest(accessTokenResponse.Message);
            }
        }

        [HttpPost]
        public IActionResult RevokeRefreshToken(AccessToken tokenResource)
        {
            GenericResponse<AccessToken> accessTokenResponse = authenticationService.RevokeRefreshToken(tokenResource.RefreshToken);
            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.Object);
            }
            else
            {
                return BadRequest(accessTokenResponse.Message);
            }
        }
    }
}