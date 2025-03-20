using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestAppMVC.Models;

public class SignUpFormModel
{
    [Display(Name = "* name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "You must enter your first name.")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "You must enter your last name.")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email", Prompt = "Enter your email")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must enter your email.")]
    [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "Your must enter a valid email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must enter your password.")]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{8,}$", ErrorMessage = "Your must enter strong password")]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password", Prompt = "Confirm you password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must confirm you password.")]
    [Compare(nameof(Password), ErrorMessage = "Yoour password does nt match")]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "Select a Cliert", Prompt = "select a client")]
    [Required(ErrorMessage = "you must select a client.")]
    public int ClientId { get; set; }

}

//add regular expressions and confirm they work correctly
//mvc formulär 46 min in