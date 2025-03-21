using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestAppMVC.Controllers
{

    [Authorize] // protect the whole controller. affect them both: secrets, nosecrets
    //If I try to access it with /Hidden/secret I will get a redirect. i comes from identity
    public class HiddenController : Controller
    {
        public IActionResult Secret()
        {
            return View();
        }


        //[Authorize] You can move it here to get access to secret but not nosecret. [Authorize (Roles = "admin")] can be usefull when only admin should be able to access the controller-method
        //[AllowAnonymous] can be used if whole controller has Authorize but you want to allow to one specific
        public IActionResult NoSecret()
        {
            return View();
        }
    }
}
