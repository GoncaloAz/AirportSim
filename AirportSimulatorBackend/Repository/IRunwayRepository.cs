using AirportSimulatorBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportSimulatorBackend.Repository
{
    public interface IRunwayRepository
    {
        Runway getRunwayInfo();

        void LockRunway(string flightCode);

        void UnlockRunway();
    }
}