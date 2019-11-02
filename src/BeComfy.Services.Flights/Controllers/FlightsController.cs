using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Dispatcher;
using BeComfy.Services.Flights.Dto;
using BeComfy.Services.Flights.Queries;
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
            => Ok(await QueryAsync(query));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDto>>> BrowseAsync([FromQuery] BrowseFlights query)
            => Ok(await QueryAsync(query));
    }
}