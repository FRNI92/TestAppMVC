using Microsoft.AspNetCore.Mvc;

namespace TestAppMVC.Controllers
{
    public class MiniMenuController : Controller
    {
        public IActionResult MiniMenu()
        {
            return PartialView("MiniMenu");
            //could not load view from MiniMenucontroller. I made this a partial and returned partial view instead. now it works
        }
    }
}
