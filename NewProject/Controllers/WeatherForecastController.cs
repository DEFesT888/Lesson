using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQlite.Models;

namespace NewProject.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;//
        private readonly ApplicationContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
            //return _context.Users.Include(u => u.Purchases).ToList();
        }

        [HttpPost("CreateUsers", Name = "CreateUser")]
        public async Task<IActionResult> CreateUser(User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.Users.Add(newUser);// ƒобавл€ет нового пользовател€ в базу данных
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetUsers", new { id = newUser.Id }, newUser);// ¬озвращает 201 и данные нового пользовател€
        }

        [HttpPut("UpdateUser/{id}", Name = "UpdateUser")]
        public IActionResult UpdateUser(Guid id, User updatedUser)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);// Ќаходит существующего пользовател€ по id

            if (existingUser == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // ќбновл€ет данные существующего пользовател€
            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;
            existingUser.Sity = updatedUser.Sity;
            existingUser.Age = updatedUser.Age;
            // —охран€ет изменени€ в базе данных
            _context.SaveChanges();

            // ¬озвращает 204 No Content, обознача€ успешное обновление
            return NoContent();
        }

        [HttpDelete("DeleteUser/{id}", Name = "DeleteUser")]
        public IActionResult DeleteUser(Guid id)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.Id == id);// Ќаходит пользовател€ по id

            if (userToDelete == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userToDelete);// ”дал€ет пользовател€ из базы данных
            _context.SaveChanges();

            return NoContent();// ¬озвращает 204 No Content, обознача€ успешное удаление
        }
    }
}
