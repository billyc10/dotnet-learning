using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace dotnet_learning.Models
{
    public class RestaurantReviewContext : DbContext
    {
        public RestaurantReviewContext(DbContextOptions<RestaurantReviewContext> options) : base(options)
        {
            var jsonString = File.ReadAllText("./Config/mock_data.json");
            var initialItems = JsonSerializer.Deserialize<List<RestaurantReview>>(jsonString);
            RestaurantReviews.AddRange(initialItems);
        }

        public DbSet<RestaurantReview> RestaurantReviews { get; set; } = null!;
    }
}
