using dotnet_learning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_learning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantReviewController : ControllerBase
    {
        private readonly ILogger<RestaurantReviewController> _logger;
        private readonly RestaurantReviewContext _dbContext;

        public RestaurantReviewController(ILogger<RestaurantReviewController> logger, RestaurantReviewContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("ping")]
        public String HelloWorld()
        {
            return "Hello World!";
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var data = _dbContext.RestaurantReviews.ToList();
            return Ok(data);
        }
    }
}