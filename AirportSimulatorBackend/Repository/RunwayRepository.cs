using AirportSimulatorBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AirportSimulatorBackend.Repository
{

    public class RunwayRepository : IRunwayRepository
    {

        private readonly ApiContext _context;

        public RunwayRepository(ApiContext context)
        {
            _context = context;
        }

        public Runway getRunwayInfo()
        {
            return _context.Runways.FirstOrDefault();
        }

        public void LockRunway(string flightCode)
        {
            Runway runway = _context.Runways.FirstOrDefault();
            runway.Available = false;
            runway.flightOnRunway = flightCode;
            _context.SaveChanges();

        }
        public void UnlockRunway()
        {
            Runway runway = _context.Runways.FirstOrDefault();
            Flight flight = _context.Flights.Where(f => f.FlightCode == runway.flightOnRunway).SingleOrDefault();


            runway.Available = true;
            runway.flightOnRunway = "";

            if (flight != null)
            {
                if (flight.Status == "Landing")
                {
                    flight.Status = "Landed";
                }
                else if (flight.Status == "Departing")
                {
                    flight.Status = "Departed";
                };

            }



            _context.SaveChanges();

        }

    }
}