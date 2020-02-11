using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Services.Flights.Domain;

namespace BeComfy.Services.Flights.Repositories
{
    public interface IFlightsRepository
    {
        Task AddAsync(Flight flight);
        Task<Flight> GetAsync(Guid id);
        Task<IEnumerable<Flight>> BrowseAsync(int pageSize, int page);
        Task UpdateAsync(Flight flight);
        Task DeleteAsync(Guid flightId);
    }
}