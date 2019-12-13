using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Interfaces.Repository
{
    public interface IUserRepository
    {
        public bool CheckUser(string userName);
        public void AddUser(TUser user);
        public void RemoveUser(TUser user);
        public TUser UpdateUser(TUser user);
        public TUser GetUserById(int tUserId);
        public TUser GetUserByUserNameAndPassword(string userName, string password);
        public void SaveRefreshToken(int userId, string refreshToken);
        public TUser GetUserWithRefreshToken(string refreshToken);
        public void RemoveRefreshToken(TUser user);
    }
}
