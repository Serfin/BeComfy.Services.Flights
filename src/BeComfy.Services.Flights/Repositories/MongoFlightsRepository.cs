using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BeComfy.Common.Mongo;
using BeComfy.Services.Flights.Domain;

namespace BeComfy.Services.Flights.Repositories
{
    public class MongoFlightsRepository : IFlightsRepository
    {
        private readonly IMongoRepository<Flight> _collection;

        public MongoFlightsRepository(IMongoRepository<Flight> collection)
        {
            _collection = collection;
        }

        public async Task AddAsync(Flight entity)
            => await _collection.AddAsync(entity);

        public async Task<IEnumerable<Flight>> BrowseAsync(int pageSize, int page)
            => await _collection.BrowseAsync(pageSize, page);

        public async Task<IEnumerable<Flight>> BrowseAsync(int pageSize, int page, Expression<Func<Flight, bool>> predicate)
            => await _collection.BrowseAsync(pageSize, page, predicate);

        public async Task DeleteAsync(Guid id)
            => await _collection.DeleteAsync(id);

        public async Task<Flight> GetAsync(Guid id)
            => await _collection.GetAsync(x => x.Id == id);

        public async Task UpdateAsync(Flight entity)
            => await _collection.UpdateAsync(entity);
    }
}