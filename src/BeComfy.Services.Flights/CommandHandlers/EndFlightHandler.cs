using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.Types.Enums;
using BeComfy.Services.Flights.Messages.Commands;
using BeComfy.Services.Flights.Messages.Events;
using BeComfy.Services.Flights.Repositories;

namespace BeComfy.Services.Flights.CommandHandlers
{
    public class EndFlightHandler : ICommandHandler<EndFlight>
    {
        private readonly IFlightsRepository _flightsRepository;
        private readonly IBusPublisher _busPublisher;

        public EndFlightHandler(IFlightsRepository flightsRepository, IBusPublisher busPublisher)
        {
            _flightsRepository = flightsRepository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(EndFlight command, ICorrelationContext context)
        {
            var flight = await _flightsRepository.GetAsync(command.Id);
            flight.SetFlightStatus(FlightStatus.Finished);
            
            await _flightsRepository.UpdateAsync(flight);
            await _busPublisher.PublishAsync(new FlightEnded(flight.PlaneId), context);
        }
    }
}