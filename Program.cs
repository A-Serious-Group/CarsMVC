using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add HttpClientFactory
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "cars",
    pattern: "cars/{action=Index}/{id?}",
    defaults: new { controller = "Cars" }
);
app.MapControllerRoute(
    name: "bodyworks",
    pattern: "bodywork/{action=Index}/{id?}",
    defaults: new { controller = "BodyWork" }
);
app.MapControllerRoute(
    name: "brands",
    pattern: "brand/{action=Index}/{id?}",
    defaults: new { controller = "Brand" }
);
app.MapControllerRoute(
    name: "lojas",
    pattern: "lojas/{action=Index}/{id?}",
    defaults: new { controller = "Lojas" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
