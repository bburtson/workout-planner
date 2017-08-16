using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WifeyApp.ViewModels;

namespace WifeyApp.Entities
{
    public interface IPlanRepository
    {

        Task <IEnumerable<DayPlan>> GetUserPlansByMonthAsync(string userName, DateTime dateTime);

        Task<IEnumerable<DayPlan>> GetAllPlansAsync(string userName, int year, int month);

        Task CreatePlanAsync(DayPlan dayPlan);

        DayPlan GetPlan(int id);
        Task<DayPlan> GetPlanAsync(string userName, DateTime dateTime);


        Task<DayPlan> UpdatePlanAsync(DayPlan dayPlan);
        Task DeletePlanAsync(DayPlan plan);

        Task CreateExcerciseAsync(Excercise excercise);
        Task<Excercise> UpdateExcerciseAsync(Excercise excercise);
        Task<int> DeleteExcerciseAsync(int id);

        Task CreateMealAsync(Meal meal);
        Task<Meal> UpdateMealAsync(Meal meal);
        Task<int> DeleteMealAsync(int id);


    }

}
