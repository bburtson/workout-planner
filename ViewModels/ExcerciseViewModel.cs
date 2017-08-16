using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WifeyApp.ViewModels
{
    public class ExcerciseViewModel
    {
        public int ExcerciseId { get; set; }

        public string Name { get; set; }

        public string TrackingOption { get; set; }

        public int TargetSets { get; set; }
        public int TargetReps { get; set; }
        public int ActualSets { get; set; }
        public int ActualReps { get; set; }
        public int Duration { get; set; }

        public int DayPlanId { get; set; }
    }

}
