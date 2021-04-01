using Microsoft.EntityFrameworkCore;

namespace AirportSimulatorBackend.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Request> Requests { get; set; }
        
    }
}