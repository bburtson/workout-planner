using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WifeyApp.ServerModules.Calendar;

namespace WifeyApp.ViewModels.Calendar
{
    public class CalendarViewModel
    {
        public string MonthName { get; set; }
        public int Year { get; set; }
        public IEnumerable<Dictionary<string, CalendarBlockViewModel>> Weeks { get; set; }
    }
}
