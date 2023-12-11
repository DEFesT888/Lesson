using Microsoft.AspNetCore.Mvc;
using SQlite.Models;

namespace NewProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;//
        private readonly List<User> _users;//������� ������ ��� �������� � �� ������ �������������

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _users = new List<User>
            {
            };
        }

        [HttpGet(Name = "GetUsers")]//��� ��������� ������ ������������� ������� ������ Post
        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        [HttpPost(Name = "CreateUser")]//����������� Id ������ ������������ � ��������� ��� � ������ �������������
        public IActionResult CreateUser(User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//������� ������ ���������
            }

            newUser.Id = Guid.NewGuid();
            _users.Add(newUser);

            return CreatedAtAction("GetUsers", _users);//������������ ������
        }

        [HttpPut("{id}", Name = "UpdateUser")]//��������� ������������� ������������
        public IActionResult UpdateUser(Guid id, User updatedUser)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);

            if (existingUser == null)
            {
                return NotFound();//���������� ���� ������������ �� ������
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//������� ������ ���������
            }

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;

            return NoContent();//�������� ���������� ������������
        }

        [HttpDelete("{id}", Name = "DeleteUser")]// ������� ������������ �� ��� Id
        public IActionResult DeleteUser(Guid id)
        {
            var userToDelete = _users.FirstOrDefault(u => u.Id == id);

            if (userToDelete == null)
            {
                return NotFound();//���������� ���� ������������ �� ������
            }

            _users.Remove(userToDelete);

            return NoContent();//�������� �������� ������������
        }
    }
}
