using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Contexts;
using CoreApiGITVersion.Interfaces.Repository;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Repositories
{
    public class RoleRepository:BaseRepository,IRoleRepository
    {
        protected readonly CoreAPIGITVersionContext Context;
        public RoleRepository(CoreAPIGITVersionContext _context) : base(_context)
        {
            Context = _context;
        }
         
        public void AddRole(TRole role)
        {
            Context.TRole.Add(role);
            Context.SaveChanges();
        }

        public TRole GetRoleById(int roleId)
        {
            return Context.TRole.Where(x => x.TRoleId == roleId && x.Enabled != false).FirstOrDefault();
        }

        public List<TRole> GetRoles()
        {
            return Context.TRole.ToList();
        } 
        public void RemoveRole(TRole role)
        {
            role.Enabled = false;
            Context.TRole.Update(role);
            Context.SaveChanges();
        } 
        public TRole UpdateRole(TRole role)
        {
            Context.TRole.Update(role);
            Context.SaveChanges();
            return Context.TRole.Find(role.TRoleId);

        }
    }
}
