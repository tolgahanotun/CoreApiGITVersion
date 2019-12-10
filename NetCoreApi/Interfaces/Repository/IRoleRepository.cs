using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Interfaces.Repository
{
    public interface IRoleRepository
    {
        public void AddRole(TRole role);
        public void RemoveRole(TRole role);
        public TRole UpdateRole(TRole role);
        public List<TRole> GetRoles();
        public TRole GetRoleById(int roleId); 
    }
}
