using System;
using System.Data;
using System.Threading.Tasks;
using BeComfy.Common.MSSQL;
using BeComfy.Services.Flights.Domain;
using Dapper;

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
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", flight.Id);
                queryParameters.Add("@PlaneId", flight.PlaneId);
                queryParameters.Add("@AvailableSeats", "TEST" /* flight.AvailableSeats */);
                queryParameters.Add("@StartAirport", flight.StartAirport);
                queryParameters.Add("@EndAirport", flight.EndAirport);
                queryParameters.Add("@FlightType", flight.FlightType);
                queryParameters.Add("@Price", flight.Price);
                queryParameters.Add("@FlightDate", flight.FlightDate);
                queryParameters.Add("@ReturnDate", flight.ReturnDate);
                queryParameters.Add("@CreatedAt", flight.CreatedAt);
                queryParameters.Add("@UpdatedAr", flight.UpdatedAt);

                await connection.ExecuteAsync("CreateFlight", queryParameters, 
                    commandType: CommandType.StoredProcedure);
            }

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