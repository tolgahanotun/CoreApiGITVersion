using CoreApiGITVersion.Response;
using CoreApiGITVersion.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiGITVersion.Interfaces.Service
{
   public interface IAuthenticationService
    {
        GenericResponse<AccessToken> CreateAccessToken(string email, string password);

        GenericResponse<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken);

        GenericResponse<AccessToken> RevokeRefreshToken(string refreshToken);
    }
}
