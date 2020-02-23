using System;
using System.Collections.Generic;
using BeComfy.Common.Types.Enums;

namespace BeComfy.Services.Flights.Services.ServiceModels
{
    public class Airplane
    {
        public Guid Guid { get; set; }
        public IDictionary<SeatClass, int> AvailableSeats { get; set; }
    }
}