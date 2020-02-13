using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Salamander.Mabas.Business.Contracts;
using Salamander.Mabas.Model.AppSettings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        private readonly IOptions<AuthorizationSettings> _authSettings;
        private readonly IAuthorizationManager _authorizationManager;
        private readonly IOrganizationManager _organizationManager;
        private readonly ICsvManager _csvManager;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IOptions<AuthorizationSettings> authSettings,
            IAuthorizationManager authorizationManager,
            IOrganizationManager organizationManager,
            ICsvManager csvManager)
        {
            _logger = logger;
            _authSettings = authSettings;
            _authorizationManager = authorizationManager;
            _organizationManager = organizationManager;
            _csvManager = csvManager;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            //_csvManager.LoadCsv("C:\\Users\\User\\Desktop\\mabas-work\\mabas1.csv");
            //_csvManager.LoadCsv("C:\\mabas6.csv");
            var authData = await _authorizationManager.RequestAccessToken(_authSettings.Value.Endpoint).ConfigureAwait(false);
            var csvData = _csvManager.LoadCsv($"{Directory.GetCurrentDirectory()}\\Files\\mabas12.csv");
            var foo = await _organizationManager.GetOrganization(authData.Data.Response.TokenId, csvData).ConfigureAwait(false);

            //_csvManager.LoadCsv(Directory.GetCurrentDirectory() + "\\Files\\mabas12.csv");

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
