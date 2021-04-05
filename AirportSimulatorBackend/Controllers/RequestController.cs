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
        // Returns all Requests and formats pagination
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

        //GET Requests/AllRequests/Active
        // Returns all requests that are marked as active
        [Route("AllRequests/Active")]
        [HttpGet]
        public IActionResult GetAllActiveRequests()
        {
            var data = _requestService.GeAllActiveRequests();

            return Ok(data);
        }

        //POST Requests/CreateRequest
        //Creates a new request in the database
        [Route("CreateRequest")]
        [HttpPost]
        public IActionResult CreateRequest(Request request)
        {
            _requestService.CreateRequest(request);
            return Ok();
        }

        //PUT Requests/AproveRequest
        //Aproves a request previously created
        [Route("AproveRequest")]
        [HttpPut]
        public IActionResult AproveRequest(Request request)
        {
            int responseCode = _requestService.AproveRequest(request);

            if (responseCode == 2)
            {
                var responseRunway = new
                {
                    message = "Runway currently being used. Unable to accept landing or departure request",
                    code = responseCode,
                };
                return Ok(responseRunway);
            }
            if (responseCode == 3)
            {
                var responseSchedule = new
                {
                    message = "There is a flight already scheduled to occupy the runway at that time",
                    code = responseCode,
                };
                return Ok(responseSchedule);
            }

            var responseSuccess = new
            {
                message = "Request Successfully aproved",
                code = responseCode,
            };
            return Ok(responseSuccess);
        }
    }
}

