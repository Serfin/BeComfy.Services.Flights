using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace BeComfy.Services.Flights.Helpers
{
    public class DapperIEnumerableGuidTypeHandler : SqlMapper.TypeHandler<IEnumerable<Guid>>
    {
        private DapperIEnumerableGuidTypeHandler()
        {

        }

        public static readonly DapperIEnumerableGuidTypeHandler Default = new DapperIEnumerableGuidTypeHandler();

        public override IEnumerable<Guid> Parse(object value) 
            => value.ToString().DeserializeTransferAirports();

        public override void SetValue(IDbDataParameter parameter, IEnumerable<Guid> value) 
            => parameter.Value = value.SerializeTransferAirports();
    }
}