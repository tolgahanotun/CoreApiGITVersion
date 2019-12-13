using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using CoreApiGITVersion.Interfaces.Repository;
using CoreApiGITVersion.Models;
using CoreApiGITVersion.Security;
using Microsoft.Extensions.Options;

namespace CoreApiGITVersion.Repositories
{
    public class UserRepository:BaseRepository,IUserRepository
    {
        private readonly CoreAPIGITVersionContext Context;
        private readonly TokenOptions tokenOptions;

        public UserRepository( CoreAPIGITVersionContext _context,IOptions<TokenOptions> _tokenOptions) : base (_context)
        {
            Context = _context;
            tokenOptions = _tokenOptions.Value;
        }

        public void AddUser(TUser user)
        {
            Context.TUser.Add(user);
            Context.SaveChanges(); 
        }

        public bool CheckUser(string userName)
        {
            return Context.TUser.Any(x => x.UserName == userName);
        }
 

        public TUser GetUserById(int tUserId)
        {
            return Context.TUser.Where(x => x.TUserId == tUserId && x.Enabled!=false).FirstOrDefault();
        }

        public TUser GetUserByUserNameAndPassword(string userName, string password)
        {
          return   Context.TUser.Where(x => x.UserName == userName && x.Password == password && x.Enabled != false).FirstOrDefault() ;
        }

        public TUser GetUserWithRefreshToken(string refreshToken)
        {
            return Context.TUser.FirstOrDefault(u => u.RefreshToken == refreshToken);
        }

        public void RemoveRefreshToken(TUser user)
        {
            TUser newUser = GetUserById(user.TUserId);
            newUser.RefreshToken = null;
            newUser.RefreshTokenEndDate = null;
            Context.SaveChanges();
        }

        public void RemoveUser(TUser user)
        {
            user.Enabled = false;
            Context.TUser.Update(user);
            Context.SaveChanges();
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            TUser newUser = GetUserById(userId);
            newUser.RefreshToken = refreshToken;
            newUser.RefreshTokenEndDate = DateTime.Now.AddMinutes(tokenOptions.RefreshTokenExpiration);
            Context.SaveChanges();

        }

        public TUser UpdateUser(TUser user)
        {
            Context.TUser.Update(user);
            Context.SaveChanges();  
            return user;
        }
    }
}
