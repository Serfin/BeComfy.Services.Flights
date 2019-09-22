using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Common.RabbitMq;
using BeComfy.Services.Flights.Domain;
using BeComfy.Services.Flights.Messages.Commands;
using BeComfy.Services.Flights.Repositories;

namespace BeComfy.Services.Flights.CommandHandlers
{
    public class CreateFlightHandler : ICommandHandler<CreateFlight>
    {
        private readonly IFlightRepository _flightsRepository;

        public CreateFlightHandler(IFlightRepository flightsRepository)
        {
            _flightsRepository = flightsRepository;
        }
        public async Task HandleAsync(CreateFlight command, ICorrelationContext context)
        {
            var flight = new Flight(command.Id, command.PlaneId, command.AvailableSeats, command.StartAirport,
                command.EndAirport, command.FlightType, command.Price, command.FlightDate, command.ReturnDate);

            await _flightsRepository.AddFlightAsync(flight);
        }
    }
}