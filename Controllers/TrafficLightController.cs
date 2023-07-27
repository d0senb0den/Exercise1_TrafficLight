using Exercise1.Enums;
using Exercise1.Models;
using Exercise1.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;

namespace Exercise1.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class TrafficLightController : ControllerBase
    {
        private TrafficLightService _trafficLightService;

        private Timer timer;
        private readonly IMemoryCache cache;
        private readonly ILogger<TrafficLightController> _logger;

        public TrafficLightController(TrafficLightService trafficLightService)
        {
            _trafficLightService = trafficLightService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<TrafficLight> GetTrafficLight()
        {
            return Ok(_trafficLightService.GetTrafficLight());
        }

    }
}