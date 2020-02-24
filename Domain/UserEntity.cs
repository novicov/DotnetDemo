using System.ComponentModel.DataAnnotations;

namespace Domain
{
    /// <summary>
    ///     Пользователь
    /// </summary>
    public class UserEntity
    {
        public UserEntity()
        {
        }

        public UserEntity(long id, string login, string firstName, string lastName, string middleName, bool isActive)
        {
            Id = id;
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            IsActive = isActive;
        }

        /// <summary>
        ///     Идентификатор сущности БД
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        ///     Логин пользователя
        /// </summary>
        public string Login { get; }

        /// <summary>
        ///     Имя
        /// </summary>
        public string FirstName { get; }


        /// <summary>
        ///     Фамилия
        /// </summary>
        public string LastName { get; }

        /// <summary>
        ///     Отчество
        /// </summary>
        public string MiddleName { get; }

        /// <summary>
        ///     Что-то неработающее
        /// </summary>

        public string NotUserField { get; private set; }

        /// <summary>
        ///     Статус пользователя (активен/неактивен)
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        ///     Блокировка пользователя
        /// </summary>
        public void Inactivate()
        {
            IsActive = false;
        }

        /// <summary>
        ///     Разблокировка пользователя
        /// </summary>
        public void Activate()
        {
            IsActive = true;
        }
    }
}