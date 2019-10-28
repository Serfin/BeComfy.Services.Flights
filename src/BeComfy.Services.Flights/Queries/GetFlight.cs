using System;
using BeComfy.Common.CqrsFlow;
using BeComfy.Services.Flights.Dto;

namespace BeComfy.Services.Flights.Queries
{
    public class GetFlight : IQuery<FlightDto>
    {
        public Guid Id { get; set; }
    }
}