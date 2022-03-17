using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlogAPI.src.Models;
using Microsoft.IdentityModel.Tokens;

namespace BlogAPI.src.Services.Implements
{
    /// <summary>
    /// <para>Resume: Class responsible for implement enterprise logic of token</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-17</para>
    /// </summary>
    public static class TokenService
    {
        #region Methods

        /// <summary>
        /// <para>Resume: Method responsible for generate token</para>
        /// <para>Description: Method claims user email and role and generate token</para>
        /// </summary>
        /// <param name="user">UserModel</param>
        /// <returns>string</returns>
        public static string GenerateToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion Methods
    }
}