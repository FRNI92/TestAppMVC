using Microsoft.AspNetCore.Mvc;

namespace TestAppMVC.Controllers;
[Route("")]
//Empty goes to projects right away when starting projects
public class ProjectsController : Controller
{
    [Route("projects")]
    public IActionResult Projects()
    {
        return View();
    }
}
