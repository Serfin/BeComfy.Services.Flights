using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeComfy.Common.MSSQL;
using BeComfy.Common.Types.Enums;
using BeComfy.Services.Flights.Domain;
using BeComfy.Services.Flights.Helpers;
using Dapper;

namespace BeComfy.Services.Flights.Repositories
{
    public class FlightsRepository : IFlightsRepository
    {
        public readonly ISqlConnector _sqlConnector;

        public FlightsRepository(ISqlConnector sqlConnector)
        {
            _sqlConnector = sqlConnector;
        }

        public async Task AddFlightAsync(Flight flight)
        {
            SqlMapper.AddTypeHandler(DapperIEnumerableGuidTypeHandler.Default);
            using (var connection = _sqlConnector.CreateConnection())
            {
                string flightType = flight.FlightType.ToString();

                connection.Open();
                await connection.ExecuteAsync("CreateFlight", 
                    new { 
                        flight.Id, 
                        flight.PlaneId,
                        flight.StartAirport,
                        flight.TransferAirports,
                        flight.EndAirport,
                        flight.FlightType,
                        flight.Price,
                        flight.FlightDate,
                        flight.ReturnDate,
                        flight.CreatedAt,
                        flight.UpdatedAt },    
                    commandType: CommandType.StoredProcedure);

                await connection.QueryAsync(PrepareInsertAvailableSeatsRequest(flight.Id, flight.AvailableSeats));
            }
        }

        public async Task<Flight> GetFlightAsync(Guid id)
        {
            SqlMapper.AddTypeHandler(DapperIEnumerableGuidTypeHandler.Default);
            var sql = $"SELECT * FROM [BeComfy.Services.Flights].[dbo].[Flights] WHERE Id = '{id.ToString()}'";
            using (var connection = _sqlConnector.CreateConnection())
            {
                var flight = await connection.QueryAsync<Flight>(sql);
                return flight.SingleOrDefault();
            }
        }

        public Task BookFlight(Guid flightId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteFlight(Guid flightId)
        {
            using (var connection = _sqlConnector.CreateConnection())
            {
                connection.Open();

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", flightId);

                await connection.ExecuteAsync("DeleteFlight", queryParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        private string PrepareInsertAvailableSeatsRequest(Guid flightId, IDictionary<SeatClass, int> availableSeats)
        {
            string prefix = "USE [BeComfy.Services.Flights] INSERT INTO [dbo].[FlightsAvailableSeats] ([FlightId], [SeatClass], [Amount]) VALUES";

            StringBuilder sb = new StringBuilder();
            sb.Append(prefix);
            foreach (var seat in availableSeats)
            {
                sb.Append($" ('{flightId}', '{seat.Key.ToString()}', {seat.Value}),");
            }
            sb.Remove(sb.ToString().Length - 1, 1);

            return sb.ToString();
        }
    }
}