using Microsoft.AspNetCore.Mvc;
using ConceptsCSharp_And_ASPNetCore.Extensions;

namespace ConceptsCSharp_And_ASPNetCore.Controllers
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

        /// <summary>
        /// Understanding how to use the method Get
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetWeatherForecast")]
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

        /// <summary>
        /// Testing method Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("tomorrowday/get")] //Defining route in attribute Route
        public async Task<IActionResult> GetTomorrow()
        {
            DateTime date = DateTime.Now;
            date = date.Tomorrow(); //Using Extension Method
            return Ok(date);
        }


        //Creating Delegate as Anonymous Method
        private delegate void petanim(string pet);


        /// <summary>
        /// Testing method post
        /// </summary>
        /// <param name="weather"></param>
        /// <returns></returns>
        [HttpPost("anonymous/post")]
        public async Task<IActionResult> SaveName(WeatherForecast weather)
        {
            petanim p = delegate (string mypet) //Anonymous Method
            {
                Console.WriteLine("Mi mascota favorita es: {0}", mypet);
            };
            p("Perro");

            return Accepted();
        }

        [HttpPatch]
        public async Task<IActionResult> ModifyName(List<WeatherForecast> weathers)
        {
            //Testing anonymous types
            //new { w.Date, w.TemperatureC };
            var weather = from w in weathers select new { w.Date, w.TemperatureC };
            foreach(var v in weather)
            {
                Console.WriteLine(v.Date.ToString() + " " + v.TemperatureC.ToString());
            }
            return Ok();
        }





    }
}