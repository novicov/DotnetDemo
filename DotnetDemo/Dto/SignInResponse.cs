﻿ namespace DotnetDemo.Dto
{
    /// <summary>
    /// Успешный ответ авторизации
    /// </summary>
    public class SignInResponse
    {
        /// <summary>
        /// Access-токен
        /// </summary>
        public AccessToken AccessToken;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="accessToken"></param>
        public SignInResponse(AccessToken accessToken)
        {
            AccessToken = accessToken;
        }
    }
}