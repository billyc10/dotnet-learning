using dotnet_learning.Models;
using System.Text.Json;

namespace dotnet_learning.Services
{
    public class InMemoryObjectStoreService : IInMemoryObjectStoreService
    {
        private List<RestaurantReview>? _db;

        public InMemoryObjectStoreService()
        {
            var jsonString = File.ReadAllText("./Config/mock_data.json");
            _db = JsonSerializer.Deserialize<List<RestaurantReview>>(jsonString);
        }

        public List<RestaurantReview>? GetData()
        {
            return _db;
        }
    }
}
