using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiGITVersion.Interfaces.Service
{
    interface IUserRoleService
    {
        public GenericResponse<TUserRole> AddUserRole(TUserRole userRole);
        public GenericResponse<List<TUserRole>> GetUserRoleByUserId(int tUserId);
        public GenericResponse<TUserRole> RemoveUserRole(TUserRole userRole);
    }
}
