using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Services.Flights.Dto;
using BeComfy.Services.Flights.Queries;
using BeComfy.Services.Flights.Repositories;

namespace BeComfy.Services.Flights.QueryHandlers
{
    public class GetFlightHandler : IQueryHandler<GetFlight, FlightDto>
    {
        private readonly IFlightsRepository _flightsRepository;

        public GetFlightHandler(IFlightsRepository flightsRepository)
        {
            _flightsRepository = flightsRepository;
        }
        
        public async Task<FlightDto> HandleAsync(GetFlight query)
        {
            var flight = await _flightsRepository.GetAsync(query.Id);

            return flight == null 
                ? null 
                : new FlightDto
                {
                    Id = flight.Id,
                    StartAirport = flight.StartAirport,
                    AvailableSeats = flight.AvailableSeats,
                    TransferAirports = flight.TransferAirports,
                    EndAirport = flight.EndAirport,
                    FlightStatus = flight.FlightStatus,
                    FlightType = flight.FlightType,
                    FlightDate = flight.FlightDate,
                    ReturnDate = flight.ReturnDate,
                };
        }
    }
}