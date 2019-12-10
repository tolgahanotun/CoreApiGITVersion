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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository RoleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;
        }

        public GenericResponse<TRole> AddRole(TRole role)
        {
            try
            {
                if (role == null) return new GenericResponse<TRole>("Role is empty");
                RoleRepository.AddRole(role);
                return new GenericResponse<TRole>(role);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TRole>(ex.Message);
            }
        }

        public GenericResponse<TRole> GetRoleById(int roleId)
        {
            try
            {
                if (roleId < 1) return new GenericResponse<TRole>("RoleId out of range");
                var role = RoleRepository.GetRoleById(roleId);
                return new GenericResponse<TRole>(role);

            }
            catch (Exception ex)
            {
                return new GenericResponse<TRole>(ex.Message);
            }

        }

        public GenericResponse<List<TRole>> GetRoles()
        {
            try
            {
                var roles = RoleRepository.GetRoles();
                return new GenericResponse<List<TRole>>(roles);
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<TRole>>(ex.Message);
            }
        }

        public GenericResponse<TRole> RemoveRole(TRole role)
        {
            try
            {
                if (role == null)
                    return new GenericResponse<TRole>("Role is empty");
                RoleRepository.RemoveRole(role);
                return new GenericResponse<TRole>(role);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TRole>(ex.Message);
            }
        }

        public GenericResponse<TRole> UpdateRole(TRole role)
        {
            try
            {
                if (role == null) return new GenericResponse<TRole>("Role is empty");
                var roleUpd = RoleRepository.UpdateRole(role);
                return new GenericResponse<TRole>(roleUpd);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TRole>(ex.Message);
            }
        }
    }
}
