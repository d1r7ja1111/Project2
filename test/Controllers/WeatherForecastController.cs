using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("TEST")]
        public IEnumerable<WEATHER> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WEATHER
            {
              
            })
            .ToArray();
        }
    }
}
