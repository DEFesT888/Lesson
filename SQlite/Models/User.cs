﻿using System.ComponentModel.DataAnnotations;

namespace SQlite.Models
{
    public class User
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Введите почту пользователя")]
        public string Email { get; set; } = null!;
        
        [MinLength(4, ErrorMessage = "Минимальная длина пароля - 4 символов")]
        [Required(ErrorMessage = "Введите пароль пользователя, это поле обязательное для заполнения")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Введите из какого вы города")]
        public string Sity { get; set; } = null!;

        [Required(ErrorMessage = "Введите возраст")]
        public int Age { get; set; }

       // public List<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
