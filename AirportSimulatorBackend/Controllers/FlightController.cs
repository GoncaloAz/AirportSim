using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AirportSimulatorBackend.Models;
using AirportSimulatorBackend.Services;
using AirportSimulatorBackend.Utils;
using Microsoft.AspNetCore.Cors;

namespace AirportSimulatorBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }


        [Route("AllFlights")]
        [HttpGet]
        public IActionResult GetAllFlights()
        {
            var data = _flightService.getAllFlights();

            return Ok(data);
        }

    }
}

