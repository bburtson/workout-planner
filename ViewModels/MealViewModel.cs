using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifeyApp.ViewModels
{
    public class MealViewModel
    {
        public int MealId { get; set; }

        public string Name { get; set; }

        public string MealOption { get; set; }

        public int Calories { get; set; }

        public int DayPlanId { get; set; }
    }
}
