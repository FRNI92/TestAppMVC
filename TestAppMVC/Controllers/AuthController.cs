using Microsoft.AspNetCore.Mvc;

namespace TestAppMVC.Controllers;

public class AuthController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult CreateAccount()
    {
        return View();
    }
}
