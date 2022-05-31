using System;
using System.Collections.Generic;

namespace Aiva.Models
{
    /// <summary>
    /// Повар.
    /// </summary>
    public class Cook
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя повара.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия повара.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// День рождения.
        /// </summary>
        public DateTime BirthdayDate { get; set; }

        /// <summary>
        /// Кухня.
        /// </summary>
        public Kitchen Kitchen { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Заказы повара.
        /// </summary>
        public ICollection<Order> Orders { get; set; }
    }
}