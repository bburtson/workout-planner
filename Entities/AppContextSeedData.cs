using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WifeyApp.Entities;

namespace WifeyApp.Entities
{
    public class AppContextSeedData
    {
        private WifeyAppDbContext _context;

        public AppContextSeedData(WifeyAppDbContext context)
        {
            _context = context;
        }


        public async Task EnsureSeedDataAsync()
        {
            if (!_context.DayPlans.Any())
            {
                var plan = new DayPlan()
                {
                    Name = "My super Duper workout Plan",
                    UserName = "christin@burtson.com",
                    DateTime = new DateTime(2017, 6, 7),
                    
                    Excercises = new List<Excercise>()
                    {
                        new Excercise()
                        {
                            Name="test one!",
                            TrackingOption = ExcerciseTrackingOption.Repetitions,
                            TargetSets = 3,
                            TargetReps = 10,
                        },

                        new Excercise()
                        {
                            Name="ANTOHER TEST",
                            TrackingOption = ExcerciseTrackingOption.Timed,
                            Duration = 23,
                            
                        }
                    },
                    Meals = new List<Meal>()
                    {
                     new Meal()
                     {
                         Name = "Protien bar",
                         MealOption = MealOption.Snack,
                         Calories = 200
                     },

                     new Meal()
                     {
                         Name = "Protien bar",
                         MealOption = MealOption.Snack,
                         Calories = 200
                     }
                    }
                    
                };


                var plan2 = new DayPlan()
                {
                    Name = "My super Duper workout Plan",
                    UserName = "brett@burtson.com",
                    DateTime = new DateTime(2017, 6, 2),
                    Excercises = new List<Excercise>()
                    {
                        new Excercise()
                        {
                            Name="test one!",
                            TrackingOption = ExcerciseTrackingOption.Repetitions,
                        },
                        new Excercise()
                        {
                            Name="ANTOHER TEST",
                            Duration = 23
                        }
                    },
                    Meals = new List<Meal>
                    {
                        new Meal()
                        {
                            Name = "Smarties!",
                            Calories = 9001
                        },
                    }
                    
                };


                _context.DayPlans.Add(plan);
                _context.DayPlans.Add(plan2);
                await _context.SaveChangesAsync();
            }
        }
    }
}
