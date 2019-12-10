using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Contexts;
using CoreApiGITVersion.Interfaces.Repository;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Repositories
{
    public class TokenRepository : BaseRepository, ITokenRepository
    {
        private readonly CoreAPIGITVersionContext Context;
        public TokenRepository(CoreAPIGITVersionContext _context) : base(_context)
        {
            Context = _context;
        }

        public void AddToken(TTokenAuthentication token)
        {
            Context.TTokenAuthentication.Add(token);
            Context.SaveChanges();
        }

        public TTokenAuthentication GetTokenByRefreshToken(TTokenAuthentication token)
        {
            return Context.TTokenAuthentication.Where(x => x.RefreshToken == token.RefreshToken && x.TokenExpired!=false).FirstOrDefault();
        }

        public void RemoveToken(TTokenAuthentication token)
        {
            token.TokenExpired = true;
            Context.TTokenAuthentication.Update(token);
            Context.SaveChanges();
        }

        public TTokenAuthentication UpdateToken(TTokenAuthentication token)
        {
            Context.TTokenAuthentication.Update(token);
            Context.SaveChanges();
            return Context.TTokenAuthentication.Find(token.TTokenId);
        }
    }
}
