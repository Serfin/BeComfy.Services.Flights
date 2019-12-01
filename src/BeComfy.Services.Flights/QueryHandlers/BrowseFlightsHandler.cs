using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Services.Flights.Dto;
using BeComfy.Services.Flights.Queries;
using BeComfy.Services.Flights.Repositories;

namespace BeComfy.Services.Flights.QueryHandlers
{
    public class BrowseFlightsHandler : IQueryHandler<BrowseFlights, IEnumerable<FlightDto>>
    {
        private readonly IFlightsRepository _flightsRepository;

        public BrowseFlightsHandler(IFlightsRepository flightsRepository)
        {
            _flightsRepository = flightsRepository;
        }

        public async Task<IEnumerable<FlightDto>> HandleAsync(BrowseFlights query)
        {
            var flights = await _flightsRepository.BrowseFlightsAsync(query.PageSize, query.Page);

            var temp = new List<FlightDto>();
            if (flights != null) 
            {
                foreach (var flight in flights)
                {
                    temp.Add(new FlightDto() 
                        {  
                            Id = flight.Id,
                            StartAirport = flight.StartAirport,
                            TransferAirports = flight.TransferAirports,
                            EndAirport = flight.EndAirport,
                            AvailableSeats = flight.AvailableSeats,
                            FlightType = flight.FlightType.ToString(),
                            Passengers = flight.Passengers,
                            FlightDate = flight.FlightDate,
                            ReturnDate = flight.ReturnDate,
                        });
                }
            }

            return temp;
        }
    }
}