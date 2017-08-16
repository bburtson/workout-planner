using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WifeyApp.Entities;
using WifeyApp.ViewModels;
using WifeyApp.ViewModels.Calendar;

namespace WifeyApp.ServerModules.Calendar
{
    public class CalendarBuilder
    {
        private IPlanRepository _planRepo;
        
        // TODO: decouple Plan repo, plenty of hooks with DateTime.
        public CalendarBuilder(IPlanRepository planRepo)
        {
            _planRepo = planRepo;
        }
        // TODO: mess refactor, reduce complexity
        public static async Task<CalendarViewModel> BuildMonthForUserAsync(IEnumerable<PlanViewModel> userPlans, DateTime dateTime)
        {
            var dt = new DateTime(dateTime.Year, dateTime.Month, 1);

            var weeks = await Task.Run(() =>
            {
                var weeksInMonth = new List<Dictionary<string, CalendarBlockViewModel>>();

                var days = new Dictionary<string, CalendarBlockViewModel>();


                for (var i = 0; i < DateTime.DaysInMonth(dt.Year, dt.Month); i++)
                {
                    var newDt = dt.AddDays(i);
                    var dayModel = new CalendarBlockViewModel(newDt);
                    days.Add(newDt.DayOfWeek.ToString(), dayModel);

                    dayModel.DayPlan = userPlans.FirstOrDefault(p => p.DateTime.Day == dayModel.Day);

                    dayModel.DayPlan = dayModel.DayPlan ?? new PlanViewModel(newDt);

                    if ((int)newDt.DayOfWeek == 6)
                    {
                        weeksInMonth.Add(days);
                        days = new Dictionary<string, CalendarBlockViewModel>();
                    }
                }

                if (days.Count > 0) weeksInMonth.Add(days);


                return weeksInMonth;
            });
            
            return new CalendarViewModel
            {
                MonthName = dateTime.ToString("MMM"),
                Year = dateTime.Year,
                Weeks = weeks
            };
        }
    }
}
