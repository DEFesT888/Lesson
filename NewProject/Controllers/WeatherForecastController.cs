using Microsoft.AspNetCore.Mvc;
using SQlite.Models;

namespace NewProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;//
        private readonly List<User> _users;//создает список для хранения в нём данных пользователей

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _users = new List<User>
            {
            };
        }

        [HttpGet(Name = "GetUsers")]//даёт прочитать данные пользователей которые принял Post
        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        [HttpPost(Name = "CreateUser")]//присваивает Id новому пользователю и добавляет его в список пользователей
        public IActionResult CreateUser(User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//возврат ошибки валидации
            }

            newUser.Id = Guid.NewGuid();
            _users.Add(newUser);

            return CreatedAtAction("GetUsers", _users);//пользователь создан
        }

        [HttpPut("{id}", Name = "UpdateUser")]//обновляет существующего пользователя
        public IActionResult UpdateUser(Guid id, User updatedUser)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);

            if (existingUser == null)
            {
                return NotFound();//возвращает если пользователь не найден
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//возврат ошибки валидации
            }

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;

            return NoContent();//успешное обновление пользователя
        }

        [HttpDelete("{id}", Name = "DeleteUser")]// удаляет пользователя по его Id
        public IActionResult DeleteUser(Guid id)
        {
            var userToDelete = _users.FirstOrDefault(u => u.Id == id);

            if (userToDelete == null)
            {
                return NotFound();//возвращает если пользователь не найден
            }

            _users.Remove(userToDelete);

            return NoContent();//успешное удаление пользователя
        }
    }
}
