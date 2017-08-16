using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WifeyApp.ViewModels;
using WifeyApp.Entities;
using System.Data.SqlClient;

namespace WifeyApp.Entities
{
    public class SqlDayPlanData : IPlanRepository
    {
        private WifeyAppDbContext _context;

        public SqlDayPlanData(WifeyAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DayPlan>> GetUserPlansByMonthAsync(string userName, DateTime dateTime)
        {
            return await Task.Run(() =>
            {
                return _context.DayPlans.Include(x => x.Excercises)
                                        .Include(x => x.Meals)
                                        .Where(p => p.UserName == userName &&
                                                    p.DateTime.Month == dateTime.Month);
            });
        }

        public async Task<IEnumerable<DayPlan>> GetAllPlansAsync(string userName, int year, int month)
        {

            return await Task.Run(() => _context.DayPlans.Include(e => e.Excercises)
                                                         .Include(m => m.Meals)
                                                         .Where(u => u.UserName == userName &&
                                                                     u.DateTime.Month == month &&
                                                                     u.DateTime.Year == year));
        }

        public async Task<DayPlan> GetPlanAsync(string userName, DateTime dateTime)
        {

            return await Task.Run(() => _context.DayPlans.Include(e => e.Excercises)
                                                         .Include(m => m.Meals)
                                                         .FirstOrDefault(p => p.UserName == userName &&
                                                                            p.DateTime == dateTime));
        }

        public DayPlan GetPlan(int id)
        {
            return _context.DayPlans.FirstOrDefault(p => p.DayPlanId == id);
        }


        public async Task<DayPlan> UpdatePlanAsync(DayPlan dayPlan)
        {
            if (dayPlan.DateTime == DateTime.MinValue)
            {
                throw new AggregateException("Type DayPlan must have a DateTime and it may not be equal to DateTime.MinValue");
            }

            await Task.Run(async () =>
            {
                _context.Update(dayPlan);

                await _context.SaveChangesAsync();

            });

            return dayPlan;
        }

        public async Task CreatePlanAsync(DayPlan dayPlan)
        {
            if (_context.DayPlans.Any(p => p.DateTime == dayPlan.DateTime &&
                                           p.UserName == dayPlan.UserName))
            {
                throw new AggregateException("Cannot have more than one DayPlan entry with the same DateTime");
            }

            await Task.Run(() => _context.Add(dayPlan));
            await _context.SaveChangesAsync();

        }

        public async Task DeletePlanAsync(DayPlan plan)
        {
            await Task.Run(() => 
            {
                _context.Remove(plan);
                _context.SaveChanges();
            });
        }

        public async Task CreateExcerciseAsync(Excercise excercise)
        {
            await Task.Run(() => _context.Add(excercise));
            await _context.SaveChangesAsync();
        }

        public async Task<Excercise> UpdateExcerciseAsync(Excercise excercise)
        {

            await Task.Run(async () =>
            {
                _context.Update(excercise);

                await _context.SaveChangesAsync();

            });

            return excercise;
        }

        public async Task<int> DeleteExcerciseAsync(int id)
        {
            var result = await Task.Run(() =>
            {
                var query = _context.Excercises.FirstOrDefault(p => p.ExcerciseId == id);

                _context.Remove(query);

                return _context.SaveChanges();

            });

            return result;
        }

        public async Task CreateMealAsync(Meal meal)
        {
            await Task.Run(() => _context.Add(meal));
            await _context.SaveChangesAsync();
        }

        public async Task<Meal> UpdateMealAsync(Meal meal)
        {

            await Task.Run(async () =>
            {
                _context.Update(meal);

                await _context.SaveChangesAsync();

            });

            return meal;
        }

        public async Task<int> DeleteMealAsync(int id)
        {
            var result = await Task.Run(() =>
            {
                var query = _context.Meals.FirstOrDefault(p => p.MealId == id);

                _context.Remove(query);

                return _context.SaveChanges();

            });

            return result;
        }
    }
}
