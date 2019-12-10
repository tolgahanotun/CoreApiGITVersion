using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using CoreApiGITVersion.Response;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Interfaces.Service
{
    interface IRoleService
    {
        public GenericResponse<TRole> AddRole(TRole role);
        public GenericResponse<TRole> RemoveRole(TRole role);
        public GenericResponse<TRole> UpdateRole(TRole role);
        public GenericResponse<List<TRole>> GetRoles();
        public GenericResponse<TRole> GetRoleById(int roleId);
    }
}
