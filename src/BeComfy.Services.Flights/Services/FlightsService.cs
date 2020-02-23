using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.Types.Enums;
using BeComfy.Common.Types.Exceptions;
using BeComfy.Services.Flights.Domain;
using BeComfy.Services.Flights.Messages.Commands;
using BeComfy.Services.Flights.Messages.Events;
using BeComfy.Services.Flights.Repositories;
using BeComfy.Services.Flights.Services.Interfaces;
using BeComfy.Services.Flights.Services.ServiceModels;

namespace BeComfy.Services.Flights.Services
{
    public class FlightsService : IFlightsService
    {
        private readonly IFlightsRepository _flightsRepository;
        private readonly IBusPublisher _busPublisher;
        private readonly IAirplanesService _airplanesService;

        public FlightsService(IFlightsRepository flightsRepository, IBusPublisher busPublisher,
            IAirplanesService airplanesService)
        {
            _flightsRepository = flightsRepository;
            _busPublisher = busPublisher;
            _airplanesService = airplanesService;
        }

        public async Task CreateFlight(CreateFlight command, ICorrelationContext context)
        {
            Airplane airplane;
            try 
            {
                airplane = await _airplanesService.Get(command.PlaneId);
            }
            catch (Exception)
            {
                // log connection exception
                airplane = null;
            }

            if (airplane is null)
            {
                throw new BeComfyException("cannot_create_flight", $"Airplane with id: '{command.PlaneId}' does not exist");
            }

            if (ValidateAvailableSeats(airplane.AvailableSeats, command.AvailableSeats))
            {
                var flight = new Flight(command.Id, command.PlaneId, command.AvailableSeats, command.StartAirport, 
                    command.TransferAirports, command.EndAirport, FlightStatus.Continues, command.FlightType, 
                    command.FlightDate, command.ReturnDate);

                await _flightsRepository.AddAsync(flight);
                await _busPublisher.PublishAsync(new FlightCreated(flight.Id, flight.PlaneId, 
                    flight.FlightDate, flight.ReturnDate), context);
            }
            else
            {
                throw new BeComfyException("cannot_create_flight", $"Invalid seats count");
            }
        }

        public async Task UpdateFlightSeats(TicketBought @event, ICorrelationContext context)
        {
            var flight = await _flightsRepository.GetAsync(@event.FlightId);

            // Decreate seats 

            await _flightsRepository.UpdateAsync(flight);
        }

        public bool ValidateAvailableSeats(IDictionary<SeatClass, int> airplaneAvailableSeats, IDictionary<SeatClass, int> flightAvailableSeats)
            => airplaneAvailableSeats[SeatClass.Economic] >= flightAvailableSeats[SeatClass.Economic] && 
                airplaneAvailableSeats[SeatClass.Business] >= flightAvailableSeats[SeatClass.Business];
    }
}