namespace DotnetDemo.Dto
{
    /// <summary>
    ///     Запрос на вход в систему
    /// </summary>
    public class SignInRequest
    {
        public SignInRequest()
        {
        }

        public SignInRequest(string login, string password)
        {
            Login = login;
            Password = password;
        }

        /// <summary>
        ///     Логин (email)
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        ///     Пароль
        /// </summary>
        public string Password { get; set; }
    }
}