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
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public GenericResponse<TUser> AddUser(TUser user)
        {
            try
            {
                if (user == null)
                    return new GenericResponse<TUser>("User is empty");
                UserRepository.AddUser(user);
                return new GenericResponse<TUser>(user);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TUser>(ex.Message);
            }

        }

        public GenericResponse<TUser> GetUserById(int tUserId)
        {
            try
            {
                if (tUserId == 0)
                    return new GenericResponse<TUser>("UserId out of range");
                var user = UserRepository.GetUserById(tUserId);
                return new GenericResponse<TUser>(user);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TUser>(ex.Message);
            }
        }

        public GenericResponse<TUser> GetUserByUserNameAndPassword(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(password))
                return new GenericResponse<TUser>("Pls check your information");

            try
            {
                return new GenericResponse<TUser>(UserRepository.GetUserByUserNameAndPassword(userName, password));
            }
            catch (Exception ex)
            {
                return new GenericResponse<TUser>(ex.Message);
            }


        }


        public GenericResponse<TUser> RemoveUser(TUser user)
        {
            try
            {
                UserRepository.RemoveUser(user);
                return new GenericResponse<TUser>(user);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TUser>(ex.Message);
            }
        }

    

        public GenericResponse<TUser> UpdateUser(TUser user)
        {
            try
            {
                if (user == null)
                    return new GenericResponse<TUser>("User is empty");
                var updatedUser = UserRepository.UpdateUser(user);
                return new GenericResponse<TUser>(updatedUser);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TUser>(ex.Message);
            }
        }


        public GenericResponse<TUser> GetUserWithRefreshToken(string refreshToken)
        {
            try
            {
                TUser user = UserRepository.GetUserWithRefreshToken(refreshToken);

                if (user == null)
                {
                    return new GenericResponse<TUser>("User not exist.");
                }
                else
                {
                    return new GenericResponse<TUser>(user);
                }
            }
            catch (Exception ex)
            {
                return new GenericResponse<TUser>(ex.Message);
            }
        }

        public void RemoveRefreshToken(TUser user)
        {
            try
            {
                UserRepository.RemoveRefreshToken(user); 
            }
            catch (Exception)
            {
                //loglama yapılacaktır.
            }
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            try
            {
                UserRepository.SaveRefreshToken(userId, refreshToken);
                 
            }
            catch (Exception)
            {
                //loglama yapılacaktır..
            }
        }

    }
}
