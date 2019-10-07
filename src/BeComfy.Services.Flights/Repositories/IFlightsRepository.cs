using System;
using System.Threading.Tasks;
using BeComfy.Services.Flights.Domain;

namespace BeComfy.Services.Flights.Repositories
{
    public interface IFlightsRepository
    {
        Task AddFlightAsync(Flight flight);
        Task<Flight> GetFlightAsync(Guid id);
        Task BookFlight(Guid flightId);
        Task DeleteFlight(Guid flightId);
    }
}