using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Contexts;
using CoreApiGITVersion.Interfaces.Repository;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Repositories
{
    public class UserRepository:BaseRepository,IUserRepository
    {
        private readonly CoreAPIGITVersionContext Context;
        public UserRepository( CoreAPIGITVersionContext _context) : base (_context)
        {
            Context = _context;
        }

        public void AddUser(TUser user)
        {
            Context.TUser.Add(user);
            Context.SaveChanges(); 
        }

        public TUser GetUserById(int tUserId)
        {
            return Context.TUser.Where(x => x.TUserId == tUserId && x.Enabled!=false).FirstOrDefault();
        }

        public void RemoveUser(TUser user)
        {
            user.Enabled = false;
            Context.TUser.Update(user);
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
