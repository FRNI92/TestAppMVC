using Business.Dtos;
using Business.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCDatabse.Data;
using MVCDatabse.Entities;
using TestAppMVC.Models;


var builder = WebApplication.CreateBuilder(args);


//dbcontext
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));
//localdb microsoft SQL server Database file. browse to correct folder. Add-migration, be in correct project. check migration

builder.Services.AddIdentity<AppUserEntity, IdentityRole>( x =>
{
    x.Password.RequiredLength = 8;// need to tell identity what we set up with dataannotations
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedEmail = false;
})
    .AddEntityFrameworkStores<DataContext>()//tells it to use EFC when using identity
    .AddDefaultTokenProviders();
//redirect when using autorize on a controller or method
//builder.Services.ConfigureApplicationCookie this parts accesses the "settings" of the cookie. x=whole cookieobjectsettings.
//then we access different specific settings with LoginPath, LogoutPath and accessdeniedpath. we also redirect them to the view we want
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/Authen/signin";
    x.LogoutPath = "/Authen/SignUp";
    x.AccessDeniedPath = "/Authen/denied";
    x.ExpireTimeSpan = TimeSpan.FromMinutes(30);// how long you are allowed to be logged in
    x.SlidingExpiration = true;//when using site it moves the times forward 30 min
});

//redirect when using autorize on a controller or method



builder.Services.AddScoped<UserService>();




builder.Services.AddControllersWithViews();


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Projects}/{action=projects}/{id?}")
    .WithStaticAssets();

app.Run();
