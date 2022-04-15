using Microsoft.AspNetCore.Mvc;

namespace Weather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("WeatherForecast")]
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

        [Route("GetAString")]
        [HttpGet]//(Name = "GetAString")]
        public string GetAString()
        {
            return ("Hello class!");
        }

        [Route("Forecast")]
        [HttpGet]//(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
           return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                        {
                            Date = DateTime.Now.AddDays(index),
                            TemperatureC = Random.Shared.Next(-20, 55),
                            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                        })
                        .ToArray();
        }
    }
}