
using System.Reflection.Metadata;
using System.Linq;
using System.Collections.Generic;
using BlogAPI.src.Data;
using BlogAPI.src.DTOs;
using BlogAPI.src.Models;
using Microsoft.EntityFrameworkCore;
using BlogAPI.src.Services.Implements;

namespace BlogAPI.src.Repositories.Implements
{
    /// <summary>
    /// <para>Resume: Class responsible for implement methos CRUD Users.</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class UserRepository : IUserRepository
    {
        #region Attributes

        private readonly AppBlogContext _context;

        #endregion Attributes

        #region Constructors

        /// <summary>
        /// <para>Resume: Constructor of class.</para>
        /// </summary>
        /// <param name="context">AppBlogContext</param>
        public UserRepository(AppBlogContext context)
        {
            _context = context;
        }

        #endregion Constructors

        #region IUserRepository implementation

        /// <summary>
        /// <para>Resume: method for get user by id.</para>
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns>UserModel</returns>
        public UserModel GetUserById(int id)
        {
            return _context.Users
                        .FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// <para>Resume: method for get user by name.</para>
        /// </summary>
        /// <param name="name">Name of user</param>
        /// <returns>List of UserModel</returns>
        public List<UserModel> GetUserByName(string name)
        {
            return _context.Users
                        .Where(u => u.Name.Contains(name))
                        .ToList();
        }

        /// <summary>
        /// <para>Resume: method for get user by email.</para>
        /// </summary>
        /// <param name="email">Email of user</param>
        /// <returns>UserModel</returns>
        public UserModel GetUserByEmail(string email)
        {
            return _context.Users
                        .FirstOrDefault(u => u.Email == email);
        }

        /// <summary>
        /// <para>Resume: method for add a new user.</para>
        /// </summary>
        /// <param name="user">UserRegisterDTO</param>
        public void AddUser(UserRegisterDTO user)
        {
            _context.Users.Add(new UserModel
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Photo = user.Photo,
                Role = user.Role
            });
            _context.SaveChanges();
        }

        /// <summary>
        /// <para>Resume: method for update am existent user.</para>
        /// </summary>
        /// <param name="user">UserUpdateDTO</param>
        public void UpdateUser(UserUpdateDTO user)
        {
            var userModel = GetUserById(user.Id);
            userModel.Name = user.Name;
            userModel.Password = UserServices.EncodePassword(user.Password);
            userModel.Photo = user.Photo;
            userModel.Role = user.Role;
            _context.Users.Update(userModel);
            _context.SaveChanges();
        }

        /// <summary>
        /// <para>Resume: method for delete a existent user.</para>
        /// </summary>
        /// <param name="id">Id of user</param>
        public void DeleteUser(int id)
        {
            _context.Users.Remove(GetUserById(id));
            _context.SaveChanges();
        }

        #endregion IUserRepository implementation
    }
}