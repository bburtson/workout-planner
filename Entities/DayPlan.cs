using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WifeyApp.ViewModels;

namespace WifeyApp.Entities
{
    public class DayPlan
    {
        public int DayPlanId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
        
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Excercise> Excercises { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }

        public string Notes { get; set; }
        public string Links { get; set; }


    }
  
}
