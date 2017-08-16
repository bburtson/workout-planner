using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WifeyApp.Entities
{
    public enum MealOption { None = 0, Snack, Meal};

    public class Meal
    {
        public int MealId { get; set; }
        [Required]
        public string Name { get; set; }

        public MealOption MealOption { get; set; }
        
        public int Calories { get; set; }

        public int DayPlanId { get; set; }
        public virtual DayPlan DayPlan { get; set; }
    }
}
