using B221210351.EFContext;
using B221210351.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services
    .AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<HastaneContext>();

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
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Login}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
