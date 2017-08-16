using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WifeyApp.ViewModels
{
    public class PlanViewModel
    {

        public int DayPlanId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }


        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        private IEnumerable<ExcerciseViewModel> _excercises;

        public IEnumerable<ExcerciseViewModel> Excercises
        {
            get { _excercises = _excercises ?? new ExcerciseViewModel[0]; return _excercises; }
            set => _excercises = value;
        }

        private IEnumerable<MealViewModel> _meals;

        public IEnumerable<MealViewModel> Meals
        {
            get { _meals = _meals ?? new MealViewModel[0]; return _meals; }
            set => _meals = value;
        }

        public string Notes { get; set; }

        public string Links { get; set; }

        public PlanViewModel() { }

        public PlanViewModel(DateTime dateTime)
        {
            DateTime = dateTime;
            Excercises = new ExcerciseViewModel[0];
            Meals = new MealViewModel[0];
        }
        public static PlanViewModel ToTemplate(DateTime dateTime)
        {
            return new PlanViewModel
            {
                DateTime = dateTime,

                Name = "Template Plan",

                Excercises = new List<ExcerciseViewModel>
                {
                    {
                        new ExcerciseViewModel
                        {
                            Name ="Template Excericse",
                            TrackingOption = "None",
                        }
                    }
                },

                Meals = new List<MealViewModel>
                {
                    new MealViewModel
                    {
                       Name = "Template Excercise",

                       MealOption = "None",
                    }
                },

                Notes = "",

                Links = "",
            };
        }


    }




}
