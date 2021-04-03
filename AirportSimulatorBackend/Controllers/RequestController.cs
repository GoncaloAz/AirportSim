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
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        //GET Requests/AllRequests/pageNumber/pageSize
        [Route("AllRequests/{pageIndex:int}/{pageSize:int}")]
        [HttpGet]
        public IActionResult GetAllRequests(int pageindex, int pageSize)
        {
            var data = _requestService.GetAllRequests();

            var page = new PaginatedResponse<Request>(data, pageindex, pageSize);
            var totalCount = data.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);

            var response = new
            {
                Page = page,
                TotalPages = totalPages
            };

            return Ok(response);
        }
    }
}

