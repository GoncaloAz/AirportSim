using AirportSimulatorBackend.Models;

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
    }
}