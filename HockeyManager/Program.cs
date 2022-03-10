using HockeyManager.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration["ConnectionString"];

builder.Services.AddMvc();
builder.Services.AddIdentity<Employee, IdentityRole>()
    .AddEntityFrameworkStores<GeneralContext>();
builder.Services.AddDbContext<GeneralContext>(options => options.UseNpgsql(connection));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseCors(builder=>
builder.
AllowAnyMethod());

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();