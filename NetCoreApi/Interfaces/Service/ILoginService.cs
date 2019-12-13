using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiGITVersion.Interfaces.Service
{
    public interface ILoginService
    {
      //  public GenericResponse<TTokenAuthentication> LoginUser(string userName, string password);
        public GenericResponse<TUser> CreateUser(string userName, string password);
    }
}
