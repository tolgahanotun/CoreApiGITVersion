using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreApiGITVersion.Models;
namespace CoreApiGITVersion.Interfaces.Repository
{
    public interface IUserRoleRepository
    {
        public void AddUserRole(TUserRole userRole);
        public IEnumerable<TUserRole> GetUserRoleByUserId(int tUserId);
        public void RemoveUserRole(TUserRole userRole); 
    }
}
