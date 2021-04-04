using AirportSimulatorBackend.Models;
using System.Collections.Generic;

namespace AirportSimulatorBackend.Services
{
    public interface IRequestService
    {
        IEnumerable<Request> GetAllRequests();
        void CreateRequest(Request request);

        Request GetRequestById(string id);
    }
}