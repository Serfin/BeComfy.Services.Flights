using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Common.Types.Enums;
using BeComfy.Services.Flights.Dto;
using BeComfy.Services.Flights.Messages.Queries;
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
            return null;
        //     var flights = await _flightsRepository.BrowseFlightsAsync(query.Page, query.PageSize);

        //     if (flights != null) 
        //     {
        //         var temp = new List<FlightDto>();

        //         foreach (var flight in flights)
        //         {
        //             temp.Add(new FlightDto() 
        //                 {  
        //                     Id = flight.Id,
        //                     StartAirport = flight.StartAirport,
        //                     TransferAirports = flight.TransferAirports,
        //                     EndAirport = flight.EndAirport,
        //                     FlightType = flight.FlightType,

        // public Guid StartAirport { get; set; }
        // public IEnumerable<Guid> TransferAirports { get; set; }
        // public Guid EndAirport { get; set; } 
        // public string FlightType { get; set; }
        // public decimal Price { get; set; }
        // public DateTime FlightDate { get; set; }
        // public DateTime? ReturnDate { get; set; } })
        //         }
        //     }

        //     return flights;
        }
    }
}