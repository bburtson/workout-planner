using Microsoft.AspNetCore.Mvc;

namespace WifeyApp.ViewComponents
{
    public class UserDetails : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
