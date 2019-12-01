using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Common.RabbitMq;
using BeComfy.Services.Flights.Domain;
using BeComfy.Services.Flights.Messages.Commands;
using BeComfy.Services.Flights.Messages.Events;
using BeComfy.Services.Flights.Repositories;

namespace BeComfy.Services.Flights.CommandHandlers
{
    public class CreateFlightHandler : ICommandHandler<CreateFlight>
    {
        private readonly IFlightsRepository _flightsRepository;
        private readonly IBusPublisher _busPublisher;

        public CreateFlightHandler(IFlightsRepository flightsRepository, IBusPublisher busPublisher)
        {
            _flightsRepository = flightsRepository;
            _busPublisher = busPublisher;
        }
        public async Task HandleAsync(CreateFlight command, ICorrelationContext context)
        {
            var flight = new Flight(command.Id, command.PlaneId, command.AvailableSeats, command.StartAirport, 
                command.TransferAirports, command.EndAirport, command.FlightType, new List<Passenger>(),
                command.FlightDate, command.ReturnDate);

            await _flightsRepository.AddFlightAsync(flight);
            await _busPublisher.PublishAsync(new FlightCreated(flight.Id, flight.PlaneId, 
                flight.FlightDate, flight.ReturnDate), context);
        }
    }
}