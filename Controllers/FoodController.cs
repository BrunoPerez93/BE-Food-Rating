using food_rating.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        [Route("Obtain/{id:int}")]
        public async Task<IActionResult> GetFoodById(int id)
        {
            var food = await _foodContext.Foods.FirstOrDefaultAsync(e => e.Id == id);
            return StatusCode(StatusCodes.Status200OK, food);
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

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditFood([FromBody] Food food)
        {
            _foodContext.Foods.Update(food);
            await _foodContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteFoodById(int id)
        {
            var food = await _foodContext.Foods.FirstOrDefaultAsync(e => e.Id == id);
            _foodContext.Foods.Remove(food);
            await _foodContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
        }
    }
}
