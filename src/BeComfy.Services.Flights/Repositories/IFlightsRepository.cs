using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Services.Flights.Domain;

namespace BeComfy.Services.Flights.Repositories
{
    public interface IFlightsRepository
    {
        Task AddFlightAsync(Flight flight);
        Task<Flight> GetFlightAsync(Guid id);
        Task<IEnumerable<Flight>> BrowseFlightsAsync(int page, int pageSize);
        Task BookFlight(Guid flightId);
        Task DeleteFlight(Guid flightId);
    }
}