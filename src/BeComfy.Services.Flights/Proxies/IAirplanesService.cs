using System;
using System.Threading.Tasks;
using BeComfy.Services.Flights.Services.ServiceModels;
using RestEase;

namespace BeComfy.Services.Flights.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IAirplanesService
    {
        [AllowAnyStatusCode]
        [Get("airplanes/{id}")]
        Task<Airplane> Get([Path] Guid id);
    }
}