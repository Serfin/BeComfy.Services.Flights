using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Common.RabbitMq;
using BeComfy.Services.Flights.Messages.Events;
using BeComfy.Services.Flights.Services.Interfaces;

namespace BeComfy.Services.Flights.EventHandlers
{
    public class TicketBoughtHandler : IEventHandler<TicketBought>
    {
        private readonly IFlightsService _flightsService;

        public TicketBoughtHandler(IFlightsService flightsService)
        {
            _flightsService = flightsService;
        }

        public async Task HandleAsync(TicketBought @event, ICorrelationContext context)
            => await _flightsService.UpdateFlightSeats(@event, context);
    }
}