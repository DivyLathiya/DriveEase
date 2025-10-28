using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using CarRentalMvc.Data; // We will create this

var builder = WebApplication.CreateBuilder(args);

// --- Add services to the container ---

// 1. Add MVC
builder.Services.AddControllersWithViews();

// 2. Add Authentication (to handle login)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Where to send users who aren't logged in
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
    });

// 3. Add a "Singleton" service for our mock data
// This simulates a database that persists for the app's lifetime
builder.Services.AddSingleton<MockDataService>();

var app = builder.Build();

// --- Configure the HTTP request pipeline ---

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // This enables CSS and JavaScript files from wwwroot

app.UseRouting();

// 5. Enable Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// 6. Map the default MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
