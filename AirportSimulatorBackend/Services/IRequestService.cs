using AirportSimulatorBackend.Models;
using System.Collections.Generic;

namespace AirportSimulatorBackend.Services
{
    public interface IRequestService
    {
        IEnumerable<Request> GetAllRequests();
        IEnumerable<Request> GeAllActiveRequests();
        void CreateRequest(Request request);

        Request GetRequestById(string id);
        int AproveRequest(Request request);

        void DenyRequest(Request request);
    }
}