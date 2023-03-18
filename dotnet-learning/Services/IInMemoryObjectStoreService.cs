using dotnet_learning.Models;

namespace dotnet_learning.Services
{
    public interface IInMemoryObjectStoreService
    {
        public List<RestaurantReview>? GetData();
    }
}
