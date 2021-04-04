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
    public class RunwayController : ControllerBase
    {
        private readonly IRunwayService _runwayService;

        public RunwayController(IRunwayService runwayService)
        {
            _runwayService = runwayService;
        }


        [Route("Info")]
        [HttpGet]
        public IActionResult GetAllActiveRequests()
        {
            var data = _runwayService.getRunwayInfo();

            return Ok(data);
        }

    }
}

