using Business.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCDatabse.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Services;


//might need to nstall identity again to make signInManager to work
public class UserService(UserManager<AppUserEntity> userManager, SignInManager<AppUserEntity> signInManager)
{
    private readonly UserManager<AppUserEntity> _userManager = userManager;
    private readonly SignInManager<AppUserEntity> _signInManager = signInManager;

    public async Task<bool> CreateAsync(AppUserDto form)//some build in function in manager
    {
        if (await _userManager.Users.AnyAsync(u => u.Email == form.Email))
            return false;
    }
}
