namespace food_rating.Model
{
    public class EEFoodRepository : IFoodRepository
    {
        private FoodContext _foodContext;
        public EEFoodRepository(FoodContext food)
        {
            _foodContext = food;
        }
        public IEnumerable<Food> Foods => _foodContext.Foods;
    }
    public interface IFoodRepository
    {
        IEnumerable<Food> Foods { get; }
    }
}
