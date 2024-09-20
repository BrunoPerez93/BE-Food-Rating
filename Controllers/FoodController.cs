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
        private readonly FoodContext _foodContext;
        public FoodController(IFoodRepository foodRepository, FoodContext foodContext)
        {
            _food = foodRepository;
            _foodContext = foodContext;
        }

        [HttpGet]
        [Route("getFood")]
        public IEnumerable<Food> Get()
        {
            var foodData = _food.Foods.ToArray();

            return foodData;
        }

        [HttpPost]
        [Route("addFood")]
        public async Task<IActionResult> AddFood([FromBody] Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _foodContext.Foods.AddAsync(food);
            await _foodContext.SaveChangesAsync();
            return Ok();

        }
    }
}
