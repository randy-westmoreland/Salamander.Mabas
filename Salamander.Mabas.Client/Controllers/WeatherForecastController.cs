using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Salamander.Mabas.Business.Contracts;

namespace Salamander.Mabas.Client.Controllers
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
        private readonly ICsvManager _csvManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICsvManager csvManager)
        {
            _logger = logger;
            _csvManager = csvManager;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //_csvManager.LoadCsv("C:\\Users\\User\\Desktop\\mabas-work\\mabas1.csv");
            //_csvManager.LoadCsv("C:\\mabas6.csv");
            _csvManager.LoadCsv(Directory.GetCurrentDirectory() + "\\Files\\mabas6.csv");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
