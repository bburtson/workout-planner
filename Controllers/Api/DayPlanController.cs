using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WifeyApp.Entities;
using WifeyApp.ViewModels;

namespace WifeyApp.Controllers.Api
{
    [Route("api/dayplan/")]
    public class DayPlanController : Controller
    {
        private IPlanRepository _planRepo;

        public DayPlanController(IPlanRepository planRepo)
        {
            _planRepo = planRepo;
        }


        [HttpGet("{date}")]
        public async Task<IActionResult> Get(string date)
        {
            var dateTime = DateTime.Parse(date);

            var plan = await _planRepo.GetPlanAsync(User.Identity.Name, dateTime).ConfigureAwait(false);

            if (plan == null) return NotFound($"No plan exists for {date}");

            var model = Mapper.Map<PlanViewModel>(plan);

            return Ok(model);
        }

        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] DayPlan plan)
        {

            var result = await _planRepo.UpdatePlanAsync(plan)
                                        .ConfigureAwait(false);

            return Ok(result);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(int id)
        {
            var plan = _planRepo.GetPlan(id);

            await _planRepo.DeletePlanAsync(plan).ConfigureAwait(false);

            return Ok($"Dayplan Id: {id}, has been deleted");
        }

        [HttpPost("meal")]
        public async Task<IActionResult> CreateMeal([FromBody] MealViewModel model)
        {

            if (ModelState.IsValid)
            {
                var meal = Mapper.Map<Meal>(model);

                await _planRepo.CreateMealAsync(meal).ConfigureAwait(false);

                var newModel = Mapper.Map<MealViewModel>(meal);

                return Created("", newModel);
            }


            return BadRequest("Invalid model name and dayplan ID are required");

        }
        [HttpPut("meal")]
        public async Task<IActionResult> UpdateMeal([FromBody] MealViewModel model)
        {
            if (ModelState.IsValid)
            {
                var meal = Mapper.Map<Meal>(model);

                await _planRepo.UpdateMealAsync(meal).ConfigureAwait(false);

                var newModel = Mapper.Map<MealViewModel>(meal);

                return Ok(newModel);
            }

            return BadRequest("Invalid model, name and dayplan ID are required");

        }
        [HttpPost("meal/{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var result = await _planRepo.DeleteMealAsync(id)
                                        .ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost("excercise")]
        public async Task<IActionResult> CreateExcercise([FromBody] ExcerciseViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid model name and dayplan ID are required");

            var excercise = Mapper.Map<Excercise>(model);

            await _planRepo.CreateExcerciseAsync(excercise).ConfigureAwait(false);

            var newModel = Mapper.Map<ExcerciseViewModel>(excercise);

            return Created("", newModel);
        }

        [HttpPut("excercise")]
        public async Task<IActionResult> UpdateExcercise([FromBody] ExcerciseViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid model name and dayplan ID are required");

            var excercise = Mapper.Map<Excercise>(model);

            await _planRepo.UpdateExcerciseAsync(excercise)
                .ConfigureAwait(false);

            var newModel = Mapper.Map<ExcerciseViewModel>(excercise);

            return Created("", newModel);
        }

        [HttpPost("excercise/{id}")]
        public async Task<IActionResult> DeleteExcercise(int id)
        {
            var result = await _planRepo.DeleteExcerciseAsync(id)
                                        .ConfigureAwait(false);

            return Ok(result);
        }


        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] PlanViewModel model)
        {
             model.UserName = User.Identity.Name;

            if (!ModelState.IsValid) return BadRequest("Invalid model");

            var plan = Mapper.Map<DayPlan>(model);

            await _planRepo.CreatePlanAsync(plan).ConfigureAwait(false);

            var url = new Uri($"http://workout.burtson.com/api/dayplan/{plan.DateTime:M,d,yyyy}");

            return Created(url, plan);
        }

    }
}
