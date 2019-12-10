using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Interfaces.Repository
{
    public interface ITokenRepository
    { 
        public void AddToken(TTokenAuthentication token);
        public TTokenAuthentication GetTokenByRefreshToken(TTokenAuthentication token);
        public void RemoveToken(TTokenAuthentication token);
        public TTokenAuthentication UpdateToken(TTokenAuthentication token);
    }
}
