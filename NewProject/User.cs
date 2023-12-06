using System.ComponentModel.DataAnnotations;

namespace NewProject
{
    //Данные что заполняются в Swager
    public class User
    {
        public Guid Id { get; set; }  //id пользователя

        [Required(ErrorMessage ="Введите имя пользователя")]
        public string Name { get; set; } = null!;  //Имя пользователя

        [Required(ErrorMessage ="Введите Ваш адрес электорнной почты")]
        public string Email { get; set; } = null!;  //Почта пользователя

        [Required(ErrorMessage ="Введите пароль, это поле является обязательным для заполнения")]
        public string Password { get; set; } = null!;  //Пароль пользователя

    }
}
