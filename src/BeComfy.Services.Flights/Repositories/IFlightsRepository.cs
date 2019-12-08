using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Common.Types.Enums;
using BeComfy.Services.Flights.Domain;

namespace BeComfy.Services.Flights.Repositories
{
    public interface IFlightsRepository
    {
        Task AddFlightAsync(Flight flight);
        Task<Flight> GetFlightAsync(Guid id);
        Task<IEnumerable<Flight>> BrowseFlightsAsync(int pageSize, int page);
        Task UpdateAsync(Flight flight);
        Task DeleteFlight(Guid flightId);
    }
}