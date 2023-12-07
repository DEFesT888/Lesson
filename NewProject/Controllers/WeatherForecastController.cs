using Microsoft.AspNetCore.Mvc;
using SQlite.Models;

namespace NewProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }/*
        [HttpPost(Name = "PostWeatherForecasty")]
        public async Task<ActionResult<ModelUser>> PostModelUser(ModelUser modelUser)
        {
            _context.ModelUser.Add(modelUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetModelUser), new { id = modelUser.Id }, modelUser);
        }*/

    }
}
