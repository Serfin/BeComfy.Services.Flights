using System;
using BeComfy.Common.Types.Enums;

namespace BeComfy.Services.Flights.Domain
{
    public class Passenger
    {
        public Guid PassengerId { get; }
        public Guid FlightId { get; private set; }
        public SeatClass SeatClass { get; private set; }

        public Passenger(Guid flightId, SeatClass seatClass)
        {
            // TODO : Domain validation
            PassengerId = Guid.NewGuid();
            FlightId = flightId;
            SeatClass = seatClass;
        }
    }
}