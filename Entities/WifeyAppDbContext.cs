using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WifeyApp.Entities
{
    public class WifeyAppDbContext : IdentityDbContext<User>
    {

        public DbSet<DayPlan> DayPlans { get; set; }
        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<User> User { get; set; }

        public WifeyAppDbContext(DbContextOptions options) : base(options) { }

    }
}
