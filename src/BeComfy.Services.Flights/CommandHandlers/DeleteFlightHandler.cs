using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Common.RabbitMq;
using BeComfy.Services.Flights.Messages.Commands;
using BeComfy.Services.Flights.Repositories;

namespace BeComfy.Services.Flights.CommandHandlers
{
    public class DeleteFlightHandler : ICommandHandler<DeleteFlight>
    {
        private readonly IFlightsRepository _flightsRepository;

        public DeleteFlightHandler(IFlightsRepository flightsRepository)
        {
            _flightsRepository = flightsRepository;
        }

        public async Task HandleAsync(DeleteFlight command, ICorrelationContext context)
            => await _flightsRepository.DeleteFlight(command.Id);
    }
}