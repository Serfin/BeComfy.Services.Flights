using System;
using System.Collections.Generic;
using System.Text;
using BeComfy.Common.Types.Enums;
using BeComfy.Common.Types.Exceptions;
using BeComfy.Services.Flights.Helpers;

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
        public string SerializedAvailableSeats { get; private set; }
        public Guid StartAirport { get; private set; }
        public IEnumerable<Guid> TransferAirports { get; private set; }
        public string SerializedTransferAirports { get; private set; }
        public Guid EndAirport { get; private set; }
        public FlightType FlightType { get; private set; }
        public decimal Price { get; private set; }
        public DateTime FlightDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Flight(Guid id, Guid planeId, IDictionary<SeatClass, int> availableSeats, 
            Guid startAirport, IEnumerable<Guid> transferAirports, Guid endAirport, 
            FlightType flightType, decimal price, DateTime flightDate, DateTime? returnDate)
        {
            Id = id;
            SetPlaneId(planeId);
            SetAvaiableSeats(availableSeats);
            SerializedTransferAirports = availableSeats.SerializeAvailableSeats();
            SetStartAirport(startAirport);
            SetTransferAirports(transferAirports);
            SerializedTransferAirports = transferAirports.SerializeTransferAirports();
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

        private void SetTransferAirports(IEnumerable<Guid> transferAirports)
        {
            if (transferAirports == null)
            {
                throw new BeComfyDomainException($"{nameof(transferAirports)} cannot be null");
            }

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

            if (flightDate == null)
            {
                throw new BeComfyDomainException($"{nameof(flightDate)} cannot be null");
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

        private int GetSeatsCount(IDictionary<SeatClass, int> seats)
        {
            int seatsCounter = 0;
            foreach (var seatClass in seats)
            {
                seatsCounter += seatClass.Value;
            }

            return seatsCounter;
        }

        private void SetUpdateDate()
            => UpdatedAt = DateTime.UtcNow;
    }
}