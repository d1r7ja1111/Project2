using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SCRAPWeatherForecastController : ControllerBase
    {


        private readonly ILogger<SCRAPWeatherForecastController> _logger;

        public SCRAPWeatherForecastController(ILogger<SCRAPWeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("TEST")]
        public IEnumerable<SCRAPWEATHER> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new SCRAPWEATHER
            {
              
            })
            .ToArray();
        }
    }
}
