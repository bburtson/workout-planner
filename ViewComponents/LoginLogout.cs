using Microsoft.AspNetCore.Mvc;

namespace WifeyApp.ViewComponents
{
    public class LoginLogout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
