﻿namespace DotnetDemo.Dto
{
    /// <summary>
    /// Токен доступа
    /// </summary>
    public class AccessToken
    {
        public AccessToken()
        {
        }

        public AccessToken(string token)
        {
            Token = token;
        }

        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; }
    }
}