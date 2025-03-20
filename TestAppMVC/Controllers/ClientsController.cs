using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestAppMVC.Controllers;

public class ClientsController : Controller
{

    [HttpPost]
    public IActionResult Add(AddClientForm form)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
                );

            return BadRequest(new { success = false, errors });
        }
        return Ok(new { success = true });
    }

    [HttpPost]
    public IActionResult Edith(EdithClientForm form)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
                );

            return BadRequest(new { success = false, errors });
        }
        //send data to our service
        return Ok(new { success = true });
    }
}
