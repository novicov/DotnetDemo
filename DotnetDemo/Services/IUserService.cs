using System.Threading.Tasks;
using DotnetDemo.Dto;

namespace DotnetDemo.Services
{
    /// <summary>
    ///     Сервис работы с пользователями системы
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///     Разблокировка пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task ActivateAsync(long userId);

        /// <summary>
        ///     Блокировка пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task InactivateAsync(long userId);

        /// <summary>
        ///     Авторизация и получение токена
        /// </summary>
        /// <param name="signInModel">Данные дял авторизации</param>
        /// <returns></returns>
        Task<SignInResponse> SignInAsync(SignInRequest signInModel);
    }
}