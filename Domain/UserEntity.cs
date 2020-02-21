using System;

namespace Domain
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserEntity
    {
        public UserEntity()
        {
        }

        public UserEntity(string firstName, string lastName, string middleName, bool isActive)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            IsActive = isActive;
        }

        /// <summary>
        /// Идентификатор сущности БД
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; private set; }

        /// <summary>
        /// Статус пользователя (активен/неактивен)
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Блокировка пользователя
        /// </summary>
        public void Inactivate()
        {
            IsActive = false;
        }

        /// <summary>
        /// Разблокировка пользователя    
        /// </summary>
        public void Activate()
        {
            IsActive = true;
        }
    }
}