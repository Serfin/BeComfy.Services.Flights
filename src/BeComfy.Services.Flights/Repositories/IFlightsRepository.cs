using System;
using System.Threading.Tasks;
using BeComfy.Services.Flights.Domain;

namespace BeComfy.Services.Flights.Repositories
{
    public interface IFlightsRepository
    {
        Task AddFlightAsync(Flight flight);
        Task DeleteFlight(Guid flightId);
        Task BookFlight(Guid flightId);
    }
}