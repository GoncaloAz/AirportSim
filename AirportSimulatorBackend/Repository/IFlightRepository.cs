using AirportSimulatorBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportSimulatorBackend.Repository
{
    public interface IFlightRepository
    {
        void CreateFlight(Flight flight);
        void UpdateFlightInfo(Flight flight);
        IEnumerable<Flight> GetAllFlights();

        Flight getFlightByFlightCode(string id);

        Flight getATCFlightEntity();
    }
}