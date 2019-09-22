using System;
using System.Collections.Generic;
using BeComfy.Common.Types.Enums;
using BeComfy.Common.Types.Exceptions;

namespace BeComfy.Services.Flights.Domain
{
    public class Flight
    {
        public Guid Id { get; private set; }
        public Guid PlaneId { get; private set; }
        public IDictionary<SeatClass, int> AvailableSeats { get; private set; }
        public Guid StartAirport { get; private set; }
        public Guid EndAirport { get; private set; }
        public FlightType FlightType { get; private set; }
        public decimal Price { get; private set; }
        public DateTime FlightDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Flight(Guid id, Guid planeId, IDictionary<SeatClass, int> availableSeats, 
            Guid startAirport, Guid endAirport, FlightType flightType, decimal price, 
            DateTime flightDate, DateTime? returnDate)
        {
            Id = id;
            SetPlaneId(planeId);
            SetAvaiableSeats(availableSeats);
            SetStartAirport(startAirport);
            SetEndAirport(endAirport);
            SetFlightType(flightType);
            SetPrice(price);
            SetFlightDate(flightDate);
            SetReturnDate(returnDate);
            CreatedAt = DateTime.UtcNow;
        }

        private void SetPlaneId(Guid planeId)
        {
            if (planeId == null)
            {
                throw new BeComfyDomainException($"{nameof(planeId)} cannot be null");
            }

            PlaneId = planeId;
            SetUpdateDate();
        }

        private void SetStartAirport(Guid startAirport)
        {
            if (startAirport == null)
            {
                throw new BeComfyDomainException($"{nameof(startAirport)} cannot be null");
            }

            StartAirport = startAirport;
            SetUpdateDate();
        }

        private void SetEndAirport(Guid endAirport)
        {
            if (endAirport == null)
            {
                throw new BeComfyDomainException($"{nameof(endAirport)} cannot be null");
            }

            EndAirport = endAirport;
            SetUpdateDate();
        }

        private void SetFlightType(FlightType flightType)
        {
            if (string.IsNullOrEmpty(flightType.ToString()))
            {
                throw new BeComfyDomainException($"{nameof(flightType)} cannot be null");
            }

            FlightType = flightType;
            SetUpdateDate();
        }

        private void SetPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new BeComfyDomainException("Price cannot be less or equal to 0");
            }

            Price = price;
            SetUpdateDate();
        }

        private void SetFlightDate(DateTime flightDate)
        {
            if (flightDate == DateTime.MinValue)
            {
                throw new BeComfyDomainException("Invalid flight date");
            }

            FlightDate = flightDate;
            SetUpdateDate();
        }

        private void SetReturnDate(DateTime? returnDate)
        {
            if (returnDate == DateTime.MinValue)
            {
                throw new BeComfyDomainException("Invalid return date");
            }

            ReturnDate = returnDate;
            SetUpdateDate();
        }

        private void SetAvaiableSeats(IDictionary<SeatClass, int> availableSeats)
        {
            if (availableSeats.Count <= 0)
            {
                throw new BeComfyDomainException("Count of seatsClass cannot be less or equal to 0");
            }

            if (GetSeatsCount(availableSeats) <= 0)
            {
                throw new BeComfyDomainException("Count of available seats cannot be less or equal to 0");
            }

            AvailableSeats = availableSeats;
            SetUpdateDate();
        }

        private void SetUpdateDate()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        private int GetSeatsCount(IDictionary<SeatClass, int> seats)
        {
            int seatsCounter = 0;
            foreach (var seatClass in seats)
            {
                seatsCounter += seatClass.Value;
            }

            return seatsCounter;
        }
    }
}