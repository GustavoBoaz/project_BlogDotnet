
using BlogAPI.src.DTOs;
using BlogAPI.src.Models;

namespace BlogAPI.src.Services
{
    /// <summary>
    /// <para>Resume: Interface responsible for enterprise logic of user service.</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-06</para>
    /// </summary>
    public interface IUserServices
    {
        UserModel CreateUserNotDuplicated(UserRegisterDTO user);
    }
}