using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.Types.Exceptions;
using BeComfy.Services.Flights.Domain;
using BeComfy.Services.Flights.Messages.Commands;
using BeComfy.Services.Flights.Repositories;

namespace BeComfy.Services.Flights.CommandHandlers
{
    // TODO : Integration with ticket microservice
    public class BookFlightHandler : ICommandHandler<BookFlight>
    {
        private readonly IFlightsRepository _flightsRepository;
        private readonly IBusPublisher _busPublisher;

        public BookFlightHandler(IFlightsRepository flightsRepository, IBusPublisher busPublisher)
        {
            _flightsRepository = flightsRepository;
            _busPublisher = busPublisher;
        }
        public async Task HandleAsync(BookFlight command, ICorrelationContext context)
        {
            var flight = await _flightsRepository.GetAsync(command.FlightId);

            if (flight is null)
            {
                throw new BeComfyException("cannot_book_flight", $"Flight with id: {command.FlightId} does not exist");
            }
            
            // TODO : Finish process
        }
    }
}