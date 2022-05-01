using System.Collections.Generic;
using BlogAPI.src.Models;
using BlogAPI.src.DTOs;

namespace BlogAPI.src.Repositories
{
    /// <summary>
    /// <para>Resume: Interface responsible for representing CRUD actions users.</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public interface IUserRepository
    {
        UserModel GetUserById(int id);
        List<UserModel> GetUserByName(string name);
        UserModel GetUserByEmail(string email);
        void AddUser(UserRegisterDTO user);
        void UpdateUser(UserUpdateDTO user);
        void DeleteUser(int id);
    }
}