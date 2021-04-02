using AirportSimulatorBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportSimulatorBackend.Repository
{
    public interface IRequestRepository
    {
        IEnumerable<Request> GetAllRequests();
        int AddRequest(Request requestEntity);
    }
}