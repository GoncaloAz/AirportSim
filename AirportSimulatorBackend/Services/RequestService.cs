using AirportSimulatorBackend.Models;
using AirportSimulatorBackend.Repository;
using System;
using System.Collections.Generic;

namespace AirportSimulatorBackend.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepo;
        private readonly IFlightRepository _flightRepo;
        public RequestService(IRequestRepository requestRepository, IFlightRepository flightRepository)
        {
            _requestRepo = requestRepository;
            _flightRepo = flightRepository;
        }

        public void CreateRequest(Request request)
        {
            if (_requestRepo.GetById(request.Flight.FlightCode) != null)
            {
                _requestRepo.CreateRequest(request);
            }
            else
            {
                _flightRepo.CreateFlight(request.Flight);
                _requestRepo.CreateRequest(request);
            }
            //_requestRepo.CreateRequest(request);
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return _requestRepo.GetAllRequests();
        }

        public Request GetRequestById(string fCode)
        {
            return _requestRepo.GetById(fCode);
        }
    }
}