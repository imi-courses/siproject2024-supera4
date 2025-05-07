using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DVD_rent.Models;

namespace DVD_rent.Models
{
    public enum Position
    {
        director,
        cashier
    }
    public class Employee : Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Должность обязательна")]
        public Position Position { get; set; }

        [Required(ErrorMessage = "Логин обязателен")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Логин должен быть от 5 до 50 символов")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Логин может содержать только буквы, цифры и подчеркивание")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Пароль должен быть от 8 до 100 символов")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "Пароль должен содержать минимум 1 заглавную букву, 1 строчную, 1 цифру и 1 спецсимвол")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();
    }
}