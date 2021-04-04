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
    }
}