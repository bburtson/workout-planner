using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WifeyApp.Entities;
using WifeyApp.ViewModels;
using static WifeyApp.ServerModules.Calendar.CalendarBuilder;

namespace WifeyApp.Controllers.Api
{
    [Route("api/calendar")]
    public class CalendarController : Controller
    {
        private IPlanRepository _planRepo;

        private WifeyAppDbContext _context;

        public CalendarController(IPlanRepository planRepository)
        {
            _planRepo = planRepository;
        }


        [HttpGet("{date}")]
        public async Task<IActionResult> Get(string date)
        {
            var dateTime = DateTime.Parse(date);

            var plans = await _planRepo.GetUserPlansByMonthAsync(User.Identity.Name, dateTime)
                                       .ConfigureAwait(false);

            var userPlans = Mapper.Map<IEnumerable<PlanViewModel>>(plans);

            var calendarModel = await BuildMonthForUserAsync(userPlans, dateTime)
                                      .ConfigureAwait(false);

            return Ok(calendarModel);
        }


    }
}
