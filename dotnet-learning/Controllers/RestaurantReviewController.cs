using dotnet_learning.Models;
using dotnet_learning.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace dotnet_learning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantReviewController : ControllerBase
    {
        private readonly ILogger<RestaurantReviewController> _logger;
        private readonly IInMemoryObjectStoreService _storeService;

        public RestaurantReviewController(ILogger<RestaurantReviewController> logger, IInMemoryObjectStoreService inMemoryObjectStoreService)
        {
            _logger = logger;
            _storeService = inMemoryObjectStoreService;
        }

        [HttpGet("ping")]
        public String HelloWorld()
        {
            return "Hello World!";
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var data = _storeService.GetData();
            return Ok(data);
        }
    }
}