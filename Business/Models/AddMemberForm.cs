﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models;

public class AddMemberForm
{
    [Display(Name = "Member Image", Prompt = "Select a image")]
    [DataType(DataType.Upload)]
    public IFormFile? MemberImage { get; set; }


    [Display(Name = "Member Name", Prompt = "Enter Member name")]
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Required")]
    public string MemberName { get; set; } = null!;

    [Display(Name = "Email", Prompt = "Enter email address")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Required")]
    [RegularExpression(@"^[^\s@]+@[^\s]+\.[^\s]+$", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Location", Prompt = "Enter your location")]
    [DataType(DataType.Text)]
    public string? Location { get; set; }

    [Display(Name = "Phonenumber", Prompt = "Enter Phonenumber")]
    [DataType(DataType.PhoneNumber)]
    public string? Phone { get; set; }

}

