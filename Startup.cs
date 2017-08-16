using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using WifeyApp.Entities;
using AutoMapper;
using WifeyApp.ViewModels;

namespace wifeyApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            Mapper.Initialize(config =>
            {
                config.CreateMap<DayPlan, PlanViewModel>().ReverseMap();
                config.CreateMap<Meal, MealViewModel>().ReverseMap();
                config.CreateMap<Excercise, ExcerciseViewModel>().ReverseMap();
                
            });

            services.AddMvc().AddJsonOptions(config=> {
                config.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddSingleton(Configuration);

            services.AddScoped<IPlanRepository, SqlDayPlanData>();

            services.AddDbContext<WifeyAppDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("WifeyApp"));
                });

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WifeyAppDbContext>();

            services.AddTransient<AppContextSeedData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, AppContextSeedData seeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            loggerFactory.AddDebug();

            loggerFactory.AddFile($"Logs/wifap-{DateTime.Now.ToString("MM-dd-yyyy")}", LogLevel.Error);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/App/Error");
            }

            app.UseFileServer();

            app.UseStaticFiles();

            app.UseIdentity();

            
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=App}/{action=Index}/{id?}");
            });


           // TODO: Mock data check if still needed, if not clean up
           // seeder.EnsureSeedDataAsync().Wait();

        }
    }
}
