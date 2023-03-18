namespace dotnet_learning.Models
{
    public class RestaurantReview
    {
        private int _rating;

        public string Name { get; set; }

        public string Location { get; set; }
        
        public string CuisineType { get; set; }

        public int Rating
        {
            get => _rating;
            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentOutOfRangeException(nameof(value), "Please enter a rating between 1 and 5");
                _rating = value;
            }
        }

        public string Description { get; set; }
    }
}