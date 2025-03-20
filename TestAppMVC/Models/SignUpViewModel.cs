using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace TestAppMVC.Models;

public class SignUpViewModel
{


    public SignUpFormModel FormData { get; set; } = new();
    public List<SelectListItem> ClientOptions = [];

    public SignUpViewModel()
    {
        
    }

    public async Task PopulateClientOptions()
    {

    }
}
