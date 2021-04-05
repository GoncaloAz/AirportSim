using AirportSimulatorBackend.Models;
using AirportSimulatorBackend.Repository;
using System;
using System.Collections.Generic;

namespace AirportSimulatorBackend.Services
{
    public class RunwayService : IRunwayService
    {
        private readonly IRunwayRepository _runwayRepo;
        public RunwayService(IRunwayRepository runwayRepository)
        {
            _runwayRepo = runwayRepository;
        }

        public Runway getRunwayInfo()
        {
            return _runwayRepo.getRunwayInfo();
        }

        public void UnlockRunway()
        {
            _runwayRepo.UnlockRunway();
        }

    }
}