using HockeyManager.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Services;
using HockeyManager.APIs;
using System.Net.Http;

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
builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();
builder.Services.AddTransient<IPlayerService, PlayerService>();
builder.Services.AddTransient<IPlayerStatisticRepository, PlayerStatisticRepository>();
builder.Services.AddTransient<IPlayerStatisticService, PlayerStatisticService>();
builder.Services.AddTransient<IPlayerContractRepository, PlayerContractRepository>();
builder.Services.AddTransient<IPlayerContractService, PlayerContractService>();
builder.Services.AddTransient<IInventoryRepository, InventoryRepository>();
builder.Services.AddTransient<IInventoryService, InventoryService>();
builder.Services.AddTransient<IEmployeeContractRepository, EmployeeContractRepository>();
builder.Services.AddTransient<IEmployeeContractService, EmployeeContractService>();
builder.Services.AddTransient<IAgentService, AgentService>();
builder.Services.AddTransient<NhlApi>();
builder.Services.AddTransient<HttpClient>();
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