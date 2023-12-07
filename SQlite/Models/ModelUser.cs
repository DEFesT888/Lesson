using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQlite.Models
{
    public class ModelUser
    {
<<<<<<< HEAD
=======
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
>>>>>>> 21b6c7c5915ff5668cc6589df14d6b4a36eb53e5
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Введите почту пользователя")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Введите пароль пользователя, это поле обязательное для заполнения")]
        public string Password { get; set; } = null!;

    }
}
