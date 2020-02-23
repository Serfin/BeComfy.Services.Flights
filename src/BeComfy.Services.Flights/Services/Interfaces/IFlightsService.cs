using System.Threading.Tasks;
using BeComfy.Common.RabbitMq;
using BeComfy.Services.Flights.Messages.Commands;
using BeComfy.Services.Flights.Messages.Events;

namespace BeComfy.Services.Flights.Services.Interfaces
{
    public interface IFlightsService
    {
        Task CreateFlight(CreateFlight command, ICorrelationContext context);
        Task UpdateFlightSeats(TicketBought @event, ICorrelationContext context);
    }
}