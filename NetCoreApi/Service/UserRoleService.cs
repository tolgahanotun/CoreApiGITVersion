using CoreApiGITVersion.Interfaces.Repository;
using CoreApiGITVersion.Interfaces.Service;
using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiGITVersion.Service
{
    public class UserRoleService:IUserRoleService
    {
        private readonly IUserRoleRepository  UserRoleRepository;
        public UserRoleService(IUserRoleRepository userRole)
        {
            UserRoleRepository = userRole;
        }

        public GenericResponse<TUserRole> AddUserRole(TUserRole userRole)
        {
            try
            {
                if (userRole == null) return new GenericResponse<TUserRole>("UserRole is empty");
                UserRoleRepository.AddUserRole(userRole);
                return new GenericResponse<TUserRole>(userRole);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TUserRole>(ex.Message);
            }
        }

        public GenericResponse<TUserRole> GetUserRoleByUserId(int tUserId)
        {
            try
            {
                if (tUserId < 1)
                    return new GenericResponse<TUserRole>("UserId out of range");
              var role=  UserRoleRepository.GetUserRoleByUserId(tUserId);
                return new GenericResponse<TUserRole>(role);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TUserRole>(ex.Message);
            }
        }

        public GenericResponse<TUserRole> RemoveUserRole(TUserRole userRole)
        {
            try
            {
                if (userRole == null) return new GenericResponse<TUserRole>("UserRole is empty");
                UserRoleRepository.RemoveUserRole(userRole);
                return new GenericResponse<TUserRole>(userRole);
            
            }
            catch (Exception ex)
            {
                return new GenericResponse<TUserRole>(ex.Message);
                 
            }
        }
    }
}
