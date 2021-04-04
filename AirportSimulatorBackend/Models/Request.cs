using System;

namespace AirportSimulatorBackend.Models
{
    public class Request
    {
        public int Id { get; set; }
        public Flight Flight { get; set; }
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public bool aproved { get; set; }
        public bool active { get; set; }
        public DateTime Created { get; set; }
    }
}