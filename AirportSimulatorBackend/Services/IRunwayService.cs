using AirportSimulatorBackend.Models;
using System.Collections.Generic;

namespace AirportSimulatorBackend.Services
{
    public interface IRunwayService
    {
        Runway getRunwayInfo();
        void UnlockRunway();
    }
}