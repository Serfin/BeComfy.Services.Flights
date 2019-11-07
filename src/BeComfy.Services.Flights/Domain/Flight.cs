using System;
using System.Collections.Generic;
using BeComfy.Common.Types.Enums;
using BeComfy.Common.Types.Exceptions;

namespace BeComfy.Services.Flights.Domain
{
    public class Flight
    {
        public Flight()
        {
            
        }

        public Guid Id { get; private set; }
        public Guid PlaneId { get; private set; }
        public IDictionary<SeatClass, int> AvailableSeats { get; private set; }
        public Guid StartAirport { get; private set; }
        public IEnumerable<Guid> TransferAirports { get; private set; }
        public Guid EndAirport { get; private set; }
        public FlightType FlightType { get; private set; }
        public decimal Price { get; private set; }
        public DateTime FlightDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Flight(Guid id, Guid planeId, Guid startAirport, IEnumerable<Guid> transferAirports, 
            Guid endAirport, FlightType flightType, DateTime flightDate, DateTime returnDate)
        {
            Id = id;
            SetPlaneId(planeId);
            SetStartAirport(startAirport);
            SetTransferAirports(transferAirports);
            SetEndAirport(endAirport);
            SetFlightType(flightType);
            SetFlightDate(flightDate);
            SetReturnDate(returnDate);
            CreatedAt = DateTime.Now;
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

        private void SetTransferAirports(IEnumerable<Guid> transferAirports)
        {
            TransferAirports = transferAirports;
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