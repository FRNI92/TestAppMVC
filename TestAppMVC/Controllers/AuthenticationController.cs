using Microsoft.AspNetCore.Mvc;
using TestAppMVC.Models;

namespace TestAppMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        private SignUpViewModel _signupviewModel = new();
        public IActionResult SignUp()
        {

            return View(_signupviewModel);
        }

        [HttpPost]//if they have the exact same name it will still go to SignUp(get) first. but now when we have string test inside SignUp and httPost
        public IActionResult SignUp(SignUpFormModel formData)
        {
            if (!ModelState.IsValid)
            {
                _signupviewModel.FormData = formData;
            return View(_signupviewModel); 
            }
        return View();

        }   //could be a good idea to return formData, will still ceep data in form
    }
}
