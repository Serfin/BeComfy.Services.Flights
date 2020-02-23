using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Common.RabbitMq;
using BeComfy.Services.Flights.Messages.Commands;
using BeComfy.Services.Flights.Services.Interfaces;

namespace BeComfy.Services.Flights.CommandHandlers
{
    public class CreateFlightHandler : ICommandHandler<CreateFlight>
    {
        private readonly IFlightsService _flightsService;

        public CreateFlightHandler(IFlightsService flightsService)
        {
            _flightsService = flightsService;
        }
        
        public async Task HandleAsync(CreateFlight command, ICorrelationContext context)
            => await _flightsService.CreateFlight(command, context);
    }
}