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

        List<Request> GetRequestsBetweenTimes(DateTime time1, DateTime time2);
        Request GetById(string id);
        void CreateRequest(Request request);

        void UpdateRequest(Request request);
    }
}