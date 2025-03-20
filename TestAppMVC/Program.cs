using Business.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCDatabse.Data;
using TestAppMVC.Models;


var builder = WebApplication.CreateBuilder(args);


//dbcontext
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));
//localdb microsoft SQL server Database file. browse to correct folder. Add-migration, be in correct project. check migration
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
