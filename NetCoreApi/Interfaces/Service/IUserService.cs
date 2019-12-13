using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiGITVersion.Interfaces.Service
{
    public interface IUserService
    {
        public GenericResponse<TUser> AddUser(TUser user);
        public GenericResponse<TUser> RemoveUser(TUser user);
        public GenericResponse<TUser> UpdateUser(TUser user);
        public GenericResponse<TUser> GetUserById(int tUserId);
        public GenericResponse<TUser> GetUserByUserNameAndPassword(string userName, string password); 
        void SaveRefreshToken(int userId, string refreshToken); 
        GenericResponse<TUser> GetUserWithRefreshToken(string refreshToken); 
        void RemoveRefreshToken(TUser user);
    }
}
