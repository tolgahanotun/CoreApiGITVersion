using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Interfaces.Repository
{
    public interface IUserRepository
    {
        public void AddUser(TUser user);
        public void RemoveUser(TUser user);
        public TUser UpdateUser(TUser user);
        public TUser GetUserById(int tUserId);
    }
}
