
using System;
using System.Text;
using BlogAPI.src.DTOs;
using BlogAPI.src.Models;
using BlogAPI.src.Repositories;

namespace BlogAPI.src.Services.Implements
{
    /// <summary>
    /// <para>Resume: Class responsible for implement enterprise logic of user</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class UserServices : IUserServices
    {
        #region Attributes

        private readonly IUserRepository _userRepository;

        #endregion Attributes

        #region Constructors

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion Constructors

        #region IUserService implementation

        /// <summary>
        /// <para>Resume: Method responsible for validate user email exist before creation</para>
        /// <para>Description: Method encodes user password and validate email before save in database</para>
        /// </summary>
        /// <param name="user">UserRegisterDTO</param>
        /// <returns>UserModel</returns>
        public UserModel CreateUserNotDuplicated(UserRegisterDTO user)
        {
            var userExists = _userRepository.GetUserByEmail(user.Email);

            if (userExists != null) return null;

            UserModel userModel = new UserModel
            {
                Name = user.Name,
                Email = user.Email,
                Password = EncodePassword(user.Password),
                Role = user.Role
            };

            user.Password = EncodePassword(user.Password);
            _userRepository.AddUser(user);

            return userModel;
        }

        /// <summary>
        /// <para>Resume: Method responsible for validate user email and password before authorization</para>
        /// <para>Description: Method encodes user password and validate email and password before authorization</para>
        /// </summary>
        /// <param name="user">UserLoginDTO</param>
        /// <returns>AuthorizationDTO</returns>
        public AuthorizationDTO GetAuthorization(UserLoginDTO user)
        {
            var userExists = _userRepository.GetUserByEmail(user.Email);

            if (userExists == null) return null;

            if (userExists.Password != EncodePassword(user.Password)) return null;

            return new AuthorizationDTO
            (
                userExists.Id,
                userExists.Name,
                userExists.Email,
                userExists.Role,
                TokenService.GenerateToken(userExists)
            );
        }

        /// <summary>
        /// <para>Resume: Method responsible for encode user password</para>
        /// </summary>
        /// <param name="password">string</param>
        /// <returns>string</returns>
        public static string EncodePassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        #endregion IUserService implementation
    }
}