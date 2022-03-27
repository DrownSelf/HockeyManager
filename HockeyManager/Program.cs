using HockeyManager.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Services;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration["ConnectionString"];

builder.Services.AddMvc();
builder.Services.AddDbContext<GeneralContext>(options =>
    options.UseNpgsql(connection));
builder.Services.AddIdentity<Employee, IdentityRole>()
    .AddEntityFrameworkStores<GeneralContext>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(GeneralRepository<>));
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IEmployeeServise, EmployeeService>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IEmployeeRoleService, EmployeeRoleService>();
builder.Services.AddTransient<IEmployeeRoleRepository, EmployeeRoleRepository>();
builder.Services.AddTransient<ISignInService, SignInService>();
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