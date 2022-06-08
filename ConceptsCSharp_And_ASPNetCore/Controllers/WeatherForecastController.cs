using Microsoft.AspNetCore.Mvc;
using ConceptsCSharp_And_ASPNetCore.Extensions;
using Services.Contracts;

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

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

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

        //IWarehouseService _warehouseService;
        //public WeatherForecastController(IWarehouseService warehouseService)
        //{
        //    _warehouseService = warehouseService;
        //}
        /// <summary>
        /// OLV esto no lo sabía :O :O :O
        /// </summary>
        /// <param name="_warehouseService"></param>
        /// <returns></returns>
        [HttpGet("GetWarehouses")]
        public IActionResult GetWarehouses([FromServices] IWarehouseService _warehouseService)
        {
            return Ok(_warehouseService.GetWarehouses());
        }


        /// <summary>
        /// Testing method Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("tomorrowday/get")] //Defining route in attribute Route
        public async Task<IActionResult> Tomorrow()
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
            //Only readonly
            //new { w.Date, w.TemperatureC };
            var weather = from w in weathers select new { w.Date, w.TemperatureC };
            foreach(var v in weather)
            {
                
                Console.WriteLine(v.Date.ToString() + " " + v.TemperatureC.ToString());
            }
            return Ok();

            Params(param1: 2, param2: 3);
        }

        void Params(int param1, int param2)
        {

        }

        [HttpGet("GetWareHouseFromQuery")]
        public IActionResult GetWareHouseFromQuery([FromQuery] int warehouseId, [FromQuery] string warehouseName)
        {
            return Ok($"Hello user id {warehouseId}, and username {warehouseName}");
        }

        [HttpGet("GetWarehouseFromRoute/{warehouseId}/{warehouseName}")]
        public IActionResult GetWarehouseFromRoute([FromRoute] int warehouseId, [FromRoute] string warehouseName)
        {
            return Ok($"Id {warehouseId} y name {warehouseName}");
        }

        [HttpPost("CreateWarehouse")]
        public IActionResult CreateWarehouse(WeatherForecast warehouse)
        {
            return Ok($"Hello this is {warehouse.Date} and temperature is {warehouse.TemperatureC}");
        }





    }
}