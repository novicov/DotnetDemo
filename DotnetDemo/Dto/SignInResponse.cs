namespace DotnetDemo.Dto
{
    /// <summary>
    ///     Успешный ответ авторизации
    /// </summary>
    public class SignInResponse
    {
        /// <summary>
        ///     Access-токен
        /// </summary>
        public string AccessToken;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="accessToken"></param>
        public SignInResponse(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}