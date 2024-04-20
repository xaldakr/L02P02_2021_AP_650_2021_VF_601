using Microsoft.EntityFrameworkCore;
using L02P02_2021_AP_650_2021_VF_601.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibreriaContexto>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("libroDbConnection")
    ));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
