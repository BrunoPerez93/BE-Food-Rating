using food_rating.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace food_rating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _food;
        public FoodController(IFoodRepository foodRepository)
        {
            _food = foodRepository;
        }

        [HttpGet]
        [Route("getFood")]
        public IEnumerable<Food> Get()
        {
            var foodData = _food.Foods.ToArray();

            return foodData;
        }
    }
}
