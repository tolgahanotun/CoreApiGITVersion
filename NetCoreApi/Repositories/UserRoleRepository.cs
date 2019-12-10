using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Contexts;
using CoreApiGITVersion.Interfaces.Repository;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Repositories
{
    public class UserRoleRepository:BaseRepository,IUserRoleRepository
    {
        private readonly CoreAPIGITVersionContext Context;
        public UserRoleRepository(CoreAPIGITVersionContext _context) : base(_context)
        {
            Context = _context;
        }

        public void AddUserRole(TUserRole userRole)
        {
            Context.TUserRole.Add(userRole);
            Context.SaveChanges();
        }

        public TUserRole GetUserRoleByUserId(int tUserId)
        {
            return Context.TUserRole.Where(x => x.TUserId == tUserId).First();
        }

        public void RemoveUserRole(TUserRole userRole)
        {
            Context.TUserRole.Remove(userRole);
            Context.SaveChanges();
        }

        
    }
}
