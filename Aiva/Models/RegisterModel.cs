using System;
using System.ComponentModel.DataAnnotations;

namespace Aiva.Models
{
    public class RegisterModel
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required(ErrorMessage = "Не указана фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// День рождения.
        /// </summary>
        [Required(ErrorMessage = "Не указана дата рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthdayDate { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        [Required(ErrorMessage = "Не указан номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        public string Kithcen { get; set; }

        public bool isClient { get; set; }

        public bool isCook { get; set; }
    }
}
