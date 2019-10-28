using System.Collections.Generic;
using BeComfy.Common.CqrsFlow;
using BeComfy.Services.Flights.Dto;

namespace BeComfy.Services.Flights.Queries
{
    public class BrowseFlights : IQuery<IEnumerable<FlightDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}