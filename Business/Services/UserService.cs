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
public class UserService(UserManager<AppUserEntity> userManager)
{
    private readonly UserManager<AppUserEntity> _userManager = userManager;


    public async Task<bool> ExistsAsync(string Email)
    {
        if (await _userManager.Users.AnyAsync(u => u.Email == Email))
            return true;

        return false;
    }

    public async Task<bool> CreateAsync(AppUserDto form)//some build in function in manager
    {
        if (form != null)
        {
            var appUser = new AppUserEntity
            {
                UserName = form.Email,
                Email = form.Email,
                FirstName = form.FirstName,
                LastName = form.LastName,
                PhoneNumber = form.Phone,

            };

            var result = await _userManager.CreateAsync(appUser, form.Password);
            return result.Succeeded;
        }

        return false;

    }
}
