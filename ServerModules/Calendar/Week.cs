using System.Collections.Generic;

namespace WifeyApp.ServerModules.Calendar
{
    public class Week
    {
        public string Month { get; set; }
        public List<Day> Dates { get; set; }
    }
}
