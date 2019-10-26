using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeComfy.Services.Flights.Domain;
using BeComfy.Services.Flights.EF;

namespace BeComfy.Services.Flights.Repositories
{
    public class FlightsRepository : IFlightsRepository
    {
        private readonly FlightsContext _context;

        public FlightsRepository(FlightsContext context)
        {
            _context = context;
        }
        public async Task AddFlightAsync(Flight flight)
        {
            await _context.Flights.AddAsync(flight);
            await _context.SaveChangesAsync();
        }

        public Task BookFlight(Guid flightId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Flight>> BrowseFlightsAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteFlight(Guid flightId)
        {
            var flight = await GetFlightAsync(flightId);
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
        }

        public async Task<Flight> GetFlightAsync(Guid id)
            => await _context.Flights.FindAsync(id);
    }
}