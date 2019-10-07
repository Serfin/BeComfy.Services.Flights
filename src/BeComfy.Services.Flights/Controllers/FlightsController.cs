using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Dispatcher;
using BeComfy.Services.Flights.Dto;
using BeComfy.Services.Flights.Messages.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BeComfy.Services.Flights.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightsController : BaseController
    {
        public FlightsController(IQueryDispatcher queryDispatcher)
            : base(queryDispatcher)
        {

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDto>> GetAsync([FromRoute] GetFlight query)
            => await QueryAsync(query);
    }
}