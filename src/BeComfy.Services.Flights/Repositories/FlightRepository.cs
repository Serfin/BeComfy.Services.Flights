using System;
using System.Threading.Tasks;
using BeComfy.Services.Flights.Domain;

namespace BeComfy.Services.Flights.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        public Task AddFlightAsync(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task BookFlight(Guid flightId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFlight(Guid flightId)
        {
            throw new NotImplementedException();
        }
    }
}