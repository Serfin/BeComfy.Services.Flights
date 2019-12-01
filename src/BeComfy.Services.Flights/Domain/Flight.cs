using System;
using System.Collections.Generic;
using System.Linq;
using BeComfy.Common.Types.Enums;
using BeComfy.Common.Types.Exceptions;
using Microsoft.AspNetCore.Http.Connections;

namespace BeComfy.Services.Flights.Domain
{
    public class Flight
    {
        public Flight()
        {
            
        }

        public Guid Id { get; private set; }
        public int PlaneId { get; private set; }
        public IDictionary<SeatClass, int> AvailableSeats { get; private set; }
        public int StartAirport { get; private set; }
        public IEnumerable<int> TransferAirports { get; private set; }
        public int EndAirport { get; private set; }
        public FlightType FlightType { get; private set; }
        public ICollection<Passenger> Passengers { get; private set; }
        public DateTime FlightDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }

        public Flight(Guid id, int planeId, IDictionary<SeatClass, int> availableSeats,
            int startAirport, IEnumerable<int> transferAirports, int endAirport, 
            FlightType flightType, ICollection<Passenger> passengers, DateTime flightDate, DateTime returnDate)
        {
            Id = id;
            SetPlaneId(planeId);
            SetAvailableSeats(availableSeats);
            SetStartAirport(startAirport);
            SetTransferAirports(transferAirports);
            SetEndAirport(endAirport);
            SetFlightType(flightType);
            SetPassengers(passengers);
            SetFlightDate(flightDate);
            SetReturnDate(returnDate);
            CreatedAt = DateTime.Now;
        }

        private void SetPlaneId(int planeId)
        {
            if (planeId == default)
            {
                throw new BeComfyDomainException($"{nameof(planeId)} cannot be set to default");
            }

            PlaneId = planeId;
            SetUpdateDate();
        }

        private void SetAvailableSeats(IDictionary<SeatClass, int> availableSeats)
        {
            if (availableSeats is null)
            {
                throw new BeComfyDomainException($"{nameof(availableSeats)} cannot be null");
            }

            int seatCount = availableSeats.Sum(seat => seat.Value);

            if (seatCount <= 0)
            {
                throw new BeComfyDomainException("Total count of seats cannot be less or equal to 0");
            }

            AvailableSeats = availableSeats;
            SetUpdateDate();
        }

        private void SetStartAirport(int startAirport)
        {
            if (startAirport == default)
            {
                throw new BeComfyDomainException($"{nameof(startAirport)} cannot be set to default");
            }

            StartAirport = startAirport;
            SetUpdateDate();
        }

        private void SetTransferAirports(IEnumerable<int> transferAirports)
        {
            TransferAirports = transferAirports;
            SetUpdateDate();
        }

        private void SetEndAirport(int endAirport)
        {
            if (endAirport == default)
            {
                throw new BeComfyDomainException($"{nameof(endAirport)} cannot be set to default");
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

        private void SetPassengers(ICollection<Passenger> passengers)
        {
            Passengers = passengers ?? throw new BeComfyDomainException($"{nameof(passengers)} cannot be null");
            SetUpdateDate();
        }

        private void SetFlightDate(DateTime flightDate)
        {
            if (flightDate == DateTime.MinValue)
            {
                throw new BeComfyDomainException("Invalid flight date");
            }

            if (flightDate == null)
            {
                throw new BeComfyDomainException($"{nameof(flightDate)} cannot be null");
            }

            FlightDate = flightDate;
            SetUpdateDate();
        }

        private void SetReturnDate(DateTime returnDate)
        {
            if (returnDate == DateTime.MinValue)
            {
                throw new BeComfyDomainException("Invalid flight date");
            }

            if (returnDate == null)
            {
                throw new BeComfyDomainException($"{nameof(returnDate)} cannot be null");
            }

            ReturnDate = returnDate;
            SetUpdateDate();
        }

        private void SetUpdateDate()
            => UpdatedAt = DateTime.Now;
    }
}