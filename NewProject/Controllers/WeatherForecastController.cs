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
            
            _context.Users.Add(newUser);// ��������� ������ ������������ � ���� ������
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetUsers", new { id = newUser.Id }, newUser);// ���������� 201 � ������ ������ ������������
        }

        [HttpPut("UpdateUser/{id}", Name = "UpdateUser")]
        public IActionResult UpdateUser(Guid id, User updatedUser)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);// ������� ������������� ������������ �� id

            if (existingUser == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // ��������� ������ ������������� ������������
            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;
            existingUser.Sity = updatedUser.Sity;
            existingUser.Age = updatedUser.Age;
            // ��������� ��������� � ���� ������
            _context.SaveChanges();

            // ���������� 204 No Content, ��������� �������� ����������
            return NoContent();
        }

        [HttpDelete("DeleteUser/{id}", Name = "DeleteUser")]
        public IActionResult DeleteUser(Guid id)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.Id == id);// ������� ������������ �� id

            if (userToDelete == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userToDelete);// ������� ������������ �� ���� ������
            _context.SaveChanges();

            return NoContent();// ���������� 204 No Content, ��������� �������� ��������
        }
    }
}
