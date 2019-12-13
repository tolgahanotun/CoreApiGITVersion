using CoreApiGITVersion.Interfaces.Repository;
using CoreApiGITVersion.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Response;
using CoreApiGITVersion.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace CoreApiGITVersion.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository UserRepository;
        private readonly IRoleRepository RoleRepository;
        private readonly IUserRoleRepository UserRoleRepository;
        public LoginService(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IRoleRepository roleRepository)
        {
            UserRepository = userRepository;
            RoleRepository = roleRepository;
            UserRoleRepository = userRoleRepository;
        }

        public GenericResponse<TUser> CreateUser(string userName, string password)
        {
            if (UserRepository.CheckUser(userName))
                return new GenericResponse<TUser>("Cannot take this username. It is exist!");
            TUser user = new TUser()
            {
                CreatedDate = DateTime.Now,
                Enabled = true,
                Name = "",
                Password = password,
                Surname = "",
                UserName = userName
            };
            UserRepository.AddUser(user);
            return new GenericResponse<TUser>(user);
        }

        //public GenericResponse<TTokenAuthentication> LoginUser(string userName, string password)
        //{
        //    try
        //    {
        //        var user = UserRepository.GetUserByUserNameAndPassword(userName, password);
        //        if (user == null)
        //            return new GenericResponse<TTokenAuthentication>("Check your information");

        //        var rolesIds = UserRoleRepository.GetUserRoleByUserId(user.TUserId);
        //        List<Claim> claimList = new List<Claim>();
        //        foreach (var userRole in rolesIds)
        //        {
        //            var role = RoleRepository.GetRoleById(userRole.TRoleId);
        //            claimList.Add(new Claim(role.RoleName, "true"));
        //        }


        //        var key = Encoding.ASCII.GetBytes
        //         ("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");
        //        var JWToken = new JwtSecurityToken(
        //            issuer: "*",
        //            audience: "*",
        //            claims: claimList.ToArray(),
        //            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
        //            expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
        //            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
        //                                SecurityAlgorithms.HmacSha256Signature)
        //        );
        //        var token = new JwtSecurityTokenHandler().WriteToken(JWToken);


        //        return new GenericResponse<TTokenAuthentication>(new TTokenAuthentication() { AccessToken = token });

        //    }
        //    catch (Exception ex)
        //    {
        //        return new GenericResponse<TTokenAuthentication>(ex.Message);
        //    }
        //}
    }
}
