using Microsoft.EntityFrameworkCore;

namespace food_rating.Model
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {
            
        }

        public DbSet<Food> Foods { get; set; }
    }
}
