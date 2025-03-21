using Business.Dtos;
using Business.Services;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCDatabse.Entities;

namespace TestAppMVC.Controllers;

public class AuthenController(UserService userService, SignInManager<AppUserEntity> signInManager) : Controller
{
    //create field, generate ctor. use primary
    private readonly UserService _userService = userService;
    private readonly SignInManager<AppUserEntity> _signInManager = signInManager;//enables signin 
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(AppUserDto form)// wants a object of type appuserdto, will return Iaction
    {
        if (!ModelState.IsValid)//validates form byt checking the dataannotations
            return View(form);//if not true return view with form and the error
        if ( await _userService.ExistsAsync(form.Email))//checks if user with same email exists
        {
            ModelState.AddModelError("Exists", "User already exists");//if exists write this
            return View(form);//if not return form
        }

        var result = await _userService.CreateAsync(form);//if email not exists, create new
        if (result)
            return RedirectToAction("SignIn", "Auth");//if created works. redirect from signupto sign in

        ModelState.AddModelError("NotCrated", "User wat not created.");//if create dont work. return to view with result(false)
        return View(result);
    }

    //will modify the Get part of sign in to handle the redirect back to the page you tried to access before being redirect to sign in
    //will return to standard "/" if we have no address
    //now we use viewbag. similar to viewdata
    public IActionResult SignIn(string returnUrl = "/")
    {
        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = "";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInFormDto form, string returnUrl = "/")// wants a object of type appuserdto, will return Iaction
        //add string returnUrl = "/" here to help with address
    {
        //if not ok, Viewbag
        if (ModelState.IsValid)//validates form byt checking the dataannotations
        {
            var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false);
            //want username/email and password, keep logged in false, lockout on fail false
            if (result.Succeeded)
            {
                if (Url.IsLocalUrl(returnUrl))//if returnUrl passes the function islocalUrl(not external) then us nex line of code
                    return Redirect(returnUrl);//redirects to the returnUrl
                return RedirectToAction("Projects", "projects");//if empty redirectaction to this view

            }
        }
        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = "Incorrect email or password";//only exists in this http request. shows message if fail. need itstatement in the view/partial view
        return View(form);//if not true return view with form and the error
    }


    //this part handles what happens when klicking singoutbutton in minimenu
    public new async Task<IActionResult> SignOut()
    {
       //the same part that has access to data about user has a method to logout
        await _signInManager.SignOutAsync();
        return RedirectToAction("Projects", "projects");//redirects to "mainpage" when logged out. might redirect to login page instead
    }
}
