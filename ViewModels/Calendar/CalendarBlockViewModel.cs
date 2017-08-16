using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WifeyApp.ViewModels.Calendar
{
    //DTO for calendar individual day blocks ** add features here later?
    public class CalendarBlockViewModel
    {

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string FullDate { get; set; }
        public string DayName { get; set; }
        public string MonthName { get; set; }
        public bool IsToday { get; set; }

        public PlanViewModel DayPlan { get; set; }



        public CalendarBlockViewModel(DateTime dateTime)
        {
            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;
            FullDate = dateTime.ToString("dddd, MMM d, yyy");
            DayName = dateTime.DayOfWeek.ToString();
            MonthName = dateTime.ToString("MMM");
            IsToday = DateTime.Today == dateTime;
        }

    }
}
