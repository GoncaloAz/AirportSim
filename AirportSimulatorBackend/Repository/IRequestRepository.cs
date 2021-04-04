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
        IEnumerable<Request> GetAllActiveRequests();
        Request GetById(string id);
        void CreateRequest(Request request);
    }
}