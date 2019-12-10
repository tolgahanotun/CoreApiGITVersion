using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiGITVersion.Interfaces.Service
{
    interface IUserService
    {
        public GenericResponse<TUser> AddUser(TUser user);
        public GenericResponse<TUser> RemoveUser(TUser user);
        public GenericResponse<TUser> UpdateUser(TUser user);
        public GenericResponse<TUser> GetUserById(int tUserId);
    }
}
