using Microsoft.AspNetCore.Mvc;

namespace dotnet_learning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantReviewController : ControllerBase
    {
        private readonly ILogger<RestaurantReviewController> _logger;

        public RestaurantReviewController(ILogger<RestaurantReviewController> logger)
        {
            _logger = logger;
        }

        [HttpGet("ping")]
        public String HelloWorld()
        {
            return "Hello World!";
        }

        [HttpGet]
        public IEnumerable<RestaurantReview> Get()
        {
            var _mockRestaurantReview = new RestaurantReview()
            {
                Date = DateTime.Now,
                Name = "Sweet Chilli",
                CuisineType = "Thai",
                Location = "Altona North",
                Rating = 5
            };

            return new List<RestaurantReview>() { _mockRestaurantReview };
        }
    }
}