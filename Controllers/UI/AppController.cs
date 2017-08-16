using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace wifeyApp.Controllers.UI
{
    public class AppController : Controller
    {
        private ILogger<AppController> _logger;

        public AppController(ILogger<AppController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home";

            return View();
        }

        [Authorize]
        public IActionResult WorkoutPlanner()
        {
            ViewData["Title"] = "Planner";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "A calendar-style workout planner.";

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult TestPage()
        {
            return View();
        }

        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();

            _logger.LogError("ErrorLoggedFrom:  HomeController.", exception.Error.Message);

            return View();
        }
    }
}
