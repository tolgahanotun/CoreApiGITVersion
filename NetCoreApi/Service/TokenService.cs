using CoreApiGITVersion.Interfaces.Repository;
using CoreApiGITVersion.Interfaces.Service;
using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiGITVersion.Service
{

    public class TokenService : ITokenService
    {
        private readonly ITokenRepository TokenRepository;
        public TokenService(ITokenRepository token)
        {
            TokenRepository = token;
        }

        public GenericResponse<TTokenAuthentication> AddToken(TTokenAuthentication token)
        {
            try
            {
                if (token == null)
                    return new GenericResponse<TTokenAuthentication>("Token is null");
                TokenRepository.AddToken(token);
                return new GenericResponse<TTokenAuthentication>(token);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TTokenAuthentication>(ex.Message);
            }
        }

        public GenericResponse<TTokenAuthentication> GetTokenByRefreshToken(TTokenAuthentication token)
        {
            try
            {
                if (token == null)
                    return new GenericResponse<TTokenAuthentication>("Token is empty");
                TokenRepository.GetTokenByRefreshToken(token);
                return new GenericResponse<TTokenAuthentication>(token);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TTokenAuthentication>(ex.Message);
            }
        }

        public GenericResponse<TTokenAuthentication> RemoveToken(TTokenAuthentication token)
        {
            try
            {
                if (token == null)
                    return new GenericResponse<TTokenAuthentication>("Token is null");
                TokenRepository.RemoveToken(token);
                return new GenericResponse<TTokenAuthentication>(token);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TTokenAuthentication>(ex.Message);
            }
        }

        public GenericResponse<TTokenAuthentication> UpdateToken(TTokenAuthentication token)
        {
            try
            {
                if (token == null) return new GenericResponse<TTokenAuthentication>("Token is empty");
                TokenRepository.UpdateToken(token);
                return new GenericResponse<TTokenAuthentication>(token);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TTokenAuthentication>(ex.Message);
            }
        }
    }
}
