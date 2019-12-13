using CoreApiGITVersion.Interfaces.Service;
using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using CoreApiGITVersion.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiGITVersion.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService userService; 
        private readonly ITokenHandler tokenHandler;

        public AuthenticationService(IUserService userService, ITokenHandler tokenHandler)
        {
            this.userService = userService;
            this.tokenHandler = tokenHandler;
        }

        public GenericResponse<AccessToken> CreateAccessToken(string userName, string password)
        {
            GenericResponse<TUser>userResponse = userService.GetUserByUserNameAndPassword(userName, password);

            if (userResponse.Success)
            {
                AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.Object);

                userService.SaveRefreshToken(userResponse.Object.TUserId, accessToken.RefreshToken);

                return new GenericResponse<AccessToken>(accessToken);
            }
            else
            {
                return new GenericResponse<AccessToken>(userResponse.Message);
            }
        }

        public GenericResponse<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken)
        {
            GenericResponse<TUser> userResponse = userService.GetUserWithRefreshToken(refreshToken);

            if (userResponse.Success)
            {
                if (userResponse.Object.RefreshTokenEndDate > DateTime.Now)
                {
                    AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.Object);

                    userService.SaveRefreshToken(userResponse.Object.TUserId    , accessToken.RefreshToken);

                    return new GenericResponse<AccessToken>(accessToken);
                }
                else
                {
                    return new GenericResponse<AccessToken>("refreshtoken suresi dolmus");
                }
            }
            else
            {
                return new GenericResponse<AccessToken>("refreshtoken bulunamadı");
            }
        }

        public GenericResponse<AccessToken> RevokeRefreshToken(string refreshToken)
        {
            GenericResponse<TUser> userResponse = userService.GetUserWithRefreshToken(refreshToken);

            if (userResponse.Success)
            {
                userService.RemoveRefreshToken(userResponse.Object);

                return new GenericResponse<AccessToken>(new AccessToken());
            }
            else
            {
                return new GenericResponse<AccessToken>("refreshtoken bulunamadı.");
            }
        }
    }
}
