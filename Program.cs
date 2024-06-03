using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AGDeberPrograP2.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AGDeberPrograP2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AGDeberPrograP2Context") ?? throw new InvalidOperationException("Connection string 'AGDeberPrograP2Context' not found.")));

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7094/WeatherForecast"); // Cambia esto por la URL base real de tu API
    // Otras configuraciones necesarias, por ejemplo, timeouts, headers, etc.
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
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
