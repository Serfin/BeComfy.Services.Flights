using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.Types.Enums;
using BeComfy.Common.Types.Exceptions;
using BeComfy.Services.Flights.Domain;
using BeComfy.Services.Flights.Messages.Commands;
using BeComfy.Services.Flights.Messages.Events;
using BeComfy.Services.Flights.Repositories;
using BeComfy.Services.Flights.Services;

namespace BeComfy.Services.Flights.CommandHandlers
{
    public class CreateFlightHandler : ICommandHandler<CreateFlight>
    {
        private readonly IFlightsRepository _flightsRepository;
        private readonly IBusPublisher _busPublisher;
        private readonly IAirplanesService _airplanesService;

        public CreateFlightHandler(IFlightsRepository flightsRepository, IBusPublisher busPublisher,
            IAirplanesService airplanesService)
        {
            _flightsRepository = flightsRepository;
            _busPublisher = busPublisher;
            _airplanesService = airplanesService;
        }
        public async Task HandleAsync(CreateFlight command, ICorrelationContext context)
        {
            var airplane = await _airplanesService.Get(command.PlaneId);

            if (airplane is null)
            {
                throw new BeComfyException($"Cannot create flight using airplane: {command.PlaneId}");
            }

            var flight = new Flight(command.Id, command.PlaneId, command.AvailableSeats, command.StartAirport, 
                command.TransferAirports, command.EndAirport, FlightStatus.Continues, command.FlightType, 
                command.FlightDate, command.ReturnDate);

            await _flightsRepository.AddFlightAsync(flight);
            await _busPublisher.PublishAsync(new FlightCreated(flight.Id, flight.PlaneId, 
                flight.FlightDate, flight.ReturnDate), context);
        }
    }
}