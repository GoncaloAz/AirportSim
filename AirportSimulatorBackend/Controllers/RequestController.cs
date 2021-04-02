using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AirportSimulatorBackend.Models;
using AirportSimulatorBackend.Services;

namespace AirportSimulatorBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [Route("AllRequests")]
        [HttpGet]
        public IEnumerable<Request> GetAllRequests()
        {
            return _requestService.GetAllRequests();
        }
    }
}
