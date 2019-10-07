using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeComfy.Common.Types.Enums;

namespace BeComfy.Services.Flights.Helpers
{
    public static class SerializationHelper
    {
        public static string SerializeTransferAirports(this IEnumerable<Guid> transferAirports)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var airportId in transferAirports)
            {
                stringBuilder.Append(airportId.ToString());
                stringBuilder.Append(";");
            }

           return stringBuilder.ToString();
        }

        public static IEnumerable<Guid> DeserializeTransferAirports(this string transferAirports)
        {
            var transfers = transferAirports.Split(';');
            List<Guid> result = new List<Guid>();

            foreach (var transfer in transfers)
            {
                result.Add(Guid.Parse(transfer));    
            }

            return (IEnumerable<Guid>) result;
        }

        public static string SerializeAvailableSeats(this IDictionary<SeatClass, int> availableSeats)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in availableSeats)
            {
                stringBuilder.Append(item.Key.ToString());
                stringBuilder.Append(":");
                stringBuilder.Append(item.Value.ToString());
                stringBuilder.Append(";");
            }

            return stringBuilder.ToString();
        }

        public static IDictionary<SeatClass, int> DeserializeAvailableSeats(this string availableSeats)
        {
            var seats = availableSeats.Split(';');
            IDictionary<SeatClass, int> result = new Dictionary<SeatClass, int>();

            foreach (var seat in seats)
            {
                var temp = seat.Split(':');

                if (Enum.TryParse(temp[0], true, out SeatClass seatClass))
                {
                    result.Add(seatClass, (int) seat[1]);
                }
            }

            return result;
        }
    }
}