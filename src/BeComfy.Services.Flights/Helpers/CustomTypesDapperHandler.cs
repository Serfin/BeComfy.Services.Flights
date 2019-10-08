using System;
using System.Collections.Generic;
using System.Data;
using BeComfy.Common.Types.Enums;
using Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace BeComfy.Services.Flights.Helpers
{
    public class DapperIEnumerableGuidTypeHandler : SqlMapper.TypeHandler<IEnumerable<Guid>>
    {
        public override IEnumerable<Guid> Parse(object value) 
            => value.ToString().DeserializeTransferAirports();

        public override void SetValue(IDbDataParameter parameter, IEnumerable<Guid> value) 
            => parameter.Value = value.SerializeTransferAirports();
    }

    public class DapperIDictionarySeatClassIntTypeHandler : SqlMapper.TypeHandler<IDictionary<SeatClass, int>>
    {
        public override IDictionary<SeatClass, int> Parse(object value)
            => value.ToString().DeserializeAvailableSeats();

        public override void SetValue(IDbDataParameter parameter, IDictionary<SeatClass, int> value)
            => parameter.Value = value.SerializeAvailableSeats();
    }

    public static class Extensions
    {
        public static void AddDapperCustomTypesHandlers(this IServiceCollection services)
        {
            SqlMapper.AddTypeHandler(new DapperIEnumerableGuidTypeHandler());
            SqlMapper.AddTypeHandler(new DapperIDictionarySeatClassIntTypeHandler());
        }
    }
}