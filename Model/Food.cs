using System.ComponentModel.DataAnnotations;

namespace food_rating.Model
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string VendorName { get; set; }
        public int FoodRating { get; set; }

    }
}
