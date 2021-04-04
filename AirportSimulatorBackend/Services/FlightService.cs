using AirportSimulatorBackend.Models;
using AirportSimulatorBackend.Repository;
using System;
using System.Collections.Generic;

namespace AirportSimulatorBackend.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepo;
        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepo = flightRepository;
        }

        public IEnumerable<Flight> getAllFlights()
        {
            return _flightRepo.GetAllFlights();
        }

        public void UpdateFlightInfo()
        {
            throw new NotImplementedException();
        }
    }
}