using Microsoft.AspNetCore.Mvc;

namespace TestAppMVC.Controllers;

public class ProjectsController : Controller
{
    public IActionResult Projects()
    {
        return View();
    }
}
