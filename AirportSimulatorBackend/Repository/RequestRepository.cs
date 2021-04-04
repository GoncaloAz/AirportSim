using AirportSimulatorBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirportSimulatorBackend.Repository
{
    public class RequestRepository : IRequestRepository
    {

        private readonly ApiContext _context;

        public RequestRepository(ApiContext context)
        {
            _context = context;
        }

        public void CreateRequest(Request request)
        {
            _context.Requests.Add(request);
            _context.SaveChanges();
        }

        public IEnumerable<Request> GetAllActiveRequests()
        {
            return _context.Requests.Where(r => r.active == true).Include("Flight").ToList();
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return _context.Requests.Include("Flight").OrderBy(p => p.Created);
        }

        public Request GetById(string fCode)
        {
            return _context.Requests.FirstOrDefault(t => t.Flight.FlightCode == fCode);
        }

        public List<Request> GetRequestsBetweenTimes(DateTime time1, DateTime time2)
        {
            return _context.Requests.Where(r => r.Time > time1 && r.Time < time2).ToList();
        }

        public void UpdateRequest(Request request)
        {

            _context.Requests.Attach(request);
            _context.Entry(request).State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}