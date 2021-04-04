using AirportSimulatorBackend.Models;
using System.Collections.Generic;

namespace AirportSimulatorBackend.Services
{
    public interface IFlightService
    {
        void UpdateFlightInfo();
        IEnumerable<Flight> getAllFlights();
    }
}