using Microsoft.AspNetCore.Mvc;

namespace BeComfy.Services.Flights.Controllers
{
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
            => Ok("BeComfy Flights Microservice");
    }
}