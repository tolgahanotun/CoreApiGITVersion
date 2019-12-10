using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiGITVersion.Interfaces.Service
{
    interface ITokenService
    {
        public GenericResponse<TTokenAuthentication> AddToken(TTokenAuthentication token);
        public GenericResponse<TTokenAuthentication> GetTokenByRefreshToken(TTokenAuthentication token);
        public GenericResponse<TTokenAuthentication> RemoveToken(TTokenAuthentication token);
        public GenericResponse<TTokenAuthentication> UpdateToken(TTokenAuthentication token);
    }
}
