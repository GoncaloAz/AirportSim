using AirportSimulatorBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AirportSimulatorBackend.Repository
{

    public class FlightRepository : IFlightRepository
    {

        private readonly ApiContext _context;

        public FlightRepository(ApiContext context)
        {
            _context = context;
        }
        public void CreateFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return _context.Flights.OrderBy(f => f.Id).ToList();
        }

        public Flight getATCFlightEntity()
        {
            return _context.Flights.First();
        }

        public Flight getFlightByFlightCode(string flightCode)
        {
            return _context.Flights.Where(flight => flight.FlightCode == flightCode).First<Flight>();
        }

        public void UpdateFlightInfo(Flight flight)
        {
            _context.Flights.Attach(flight);
            _context.Entry(flight).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}