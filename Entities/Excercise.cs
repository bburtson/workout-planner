using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WifeyApp.Entities
{
    public enum ExcerciseTrackingOption { None = 0, Repetitions, Timed}
    public class Excercise
    {
        public int ExcerciseId { get; set; }

        [Required]
        public string Name { get; set; }

        public ExcerciseTrackingOption TrackingOption{ get; set; }

        public int TargetSets { get; set; }
        public int TargetReps { get; set; }
        public int ActualSets { get; set; }
        public int ActualReps { get; set; }
        public int Duration { get; set; }

        public int DayPlanId { get; set; }
        public virtual DayPlan DayPlan { get; set; }
    }
}
