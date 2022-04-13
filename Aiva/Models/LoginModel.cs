using System;
using System.ComponentModel.DataAnnotations;

namespace Aiva.Models
{
    public class LoginModel
    {
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
    }
}
