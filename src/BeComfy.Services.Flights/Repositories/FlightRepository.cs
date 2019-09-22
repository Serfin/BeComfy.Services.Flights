using System;
using System.Data;
using System.Threading.Tasks;
using BeComfy.Common.MSSQL;
using BeComfy.Services.Flights.Domain;

namespace BeComfy.Services.Flights.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        public readonly ISqlConnector _sqlConnector;

        public FlightRepository(ISqlConnector sqlConnector)
        {
            _sqlConnector = sqlConnector;
        }
        public async Task AddFlightAsync(Flight flight)
        {
            using (var connection = _sqlConnector.CreateConnection())
            {
                connection.Open();
                connection.Close();
            }
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