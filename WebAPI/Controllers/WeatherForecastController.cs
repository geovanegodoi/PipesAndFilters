using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paramore.Brighter;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Commands;
using WebAPI.Filters;
using WebAPI.Queries;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly CommandProcessor _commandProcessor;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CommandProcessor commandProcessor)
        {
            _logger = logger;
            _commandProcessor = commandProcessor;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get([FromQuery]bool exception = false)
        {
            if (exception)
                throw new Exception("Excecao de teste!!!");

            var rnd = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date         = DateTime.Now.AddDays(index),
                TemperatureC = rnd.Next(-20, 55),
                Summary      = Summaries[rnd.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("Welcome")]
        public IActionResult PostGreeting()
        {
            _commandProcessor.Send(new GreetingCommand("Ola seja bemvindo"));

            return Ok("Realizado com sucesso");
        }

        [HttpPost("Orders")]
        public IActionResult Post()
        {
            _commandProcessor.Send(new PlaceOrderCommand(Guid.NewGuid()));

            return Ok("Realizado com sucesso");
        }

        [HttpGet("WeeklyReports")]
        public IActionResult GetReport()
        {
            _commandProcessor.Send(new WeeklyReportQuery() { Id = Guid.NewGuid() });

            return Ok("Realizado com sucesso");
        }
    }
}
