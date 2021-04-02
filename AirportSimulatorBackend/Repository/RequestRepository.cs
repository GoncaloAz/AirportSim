using AirportSimulatorBackend.Models;
using Microsoft.EntityFrameworkCore;
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
        public int AddRequest(Request requestEntity)
        {
            int result = 0;

            if (requestEntity != null)
            {
                _context.Requests.Add(requestEntity);
                _context.SaveChanges();
                result = requestEntity.Id;
            }
            return result;

        }

        public IEnumerable<Request> GetAllRequests()
        {
            return _context.Requests.Include("Flight").OrderBy(p => p.Created);
        }

    }
}