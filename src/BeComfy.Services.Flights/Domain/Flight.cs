using System;
using System.Collections.Generic;
using System.Linq;
using BeComfy.Common.Mongo;
using BeComfy.Common.Types.Enums;
using BeComfy.Common.Types.Exceptions;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace BeComfy.Services.Flights.Domain
{
    public class Flight : IEntity
    {
        public Guid Id { get; private set; }
        public Guid PlaneId { get; private set; }
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public IDictionary<SeatClass, int> AvailableSeats { get; private set; }
        public Guid StartAirport { get; private set; }
        public IEnumerable<Guid> TransferAirports { get; private set; }
        public Guid EndAirport { get; private set; }
        public FlightStatus FlightStatus { get; private set; }
        public FlightType FlightType { get; private set; }
        public DateTime FlightDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }
        
        public Flight()
        {
            
        }

        public Flight(Guid id, Guid planeId, IDictionary<SeatClass, int> availableSeats,
            Guid startAirport, IEnumerable<Guid> transferAirports, Guid endAirport, 
            FlightStatus flightStatus, FlightType flightType, DateTime flightDate, DateTime returnDate)
        {
            Id = id;
            SetPlaneId(planeId);
            SetAvailableSeats(availableSeats);
            SetStartAirport(startAirport);
            SetTransferAirports(transferAirports);
            SetEndAirport(endAirport);
            SetFlightStatus(flightStatus);
            SetFlightType(flightType);
            SetFlightDate(flightDate);
            SetReturnDate(returnDate);
            CreatedAt = DateTime.Now;
        }

        private void SetPlaneId(Guid planeId)
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

        private void SetStartAirport(Guid startAirport)
        {
            if (startAirport == default)
            {
                throw new BeComfyDomainException($"{nameof(startAirport)} cannot be set to default");
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
            if (endAirport == default)
            {
                throw new BeComfyDomainException($"{nameof(endAirport)} cannot be set to default");
            }

            EndAirport = endAirport;
            SetUpdateDate();
        }

        public void SetFlightStatus(FlightStatus flightStatus)
        {
            if (string.IsNullOrEmpty(flightStatus.ToString()))
            {
                throw new BeComfyDomainException($"{nameof(flightStatus)} cannot be null");
            }

            FlightStatus = flightStatus;
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