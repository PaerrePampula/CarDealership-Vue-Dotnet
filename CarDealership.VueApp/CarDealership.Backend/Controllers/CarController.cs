using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Backend.Controllers
{
    [ApiController]
    [Route("api")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }
    }
}
