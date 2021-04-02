using AirportSimulatorBackend.Models;
using AirportSimulatorBackend.Repository;
using System;
using System.Collections.Generic;

namespace AirportSimulatorBackend.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepo;
        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepo = requestRepository;
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return _requestRepo.GetAllRequests();
        }


    }
}