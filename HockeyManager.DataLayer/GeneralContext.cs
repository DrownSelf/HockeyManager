using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql.EntityFrameworkCore;

namespace HockeyManager.DataLayer
{
    public class GeneralContext : IdentityDbContext<Employee>
    {

        public GeneralContext(DbContextOptions<GeneralContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string userId = this.SeedEmployee(builder);
            string roleId = this.SeedRole(builder);
            this.SeedUserRole(builder, userId, roleId);
        }

        private string SeedEmployee(ModelBuilder builder)
        {
            var admin = new Employee
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Admin",
                Email = "admin@gmail.com",
            };
            admin.NormalizedEmail = admin.Email.ToUpper();
            admin.NormalizedUserName = admin.UserName.ToUpper();
            admin.PasswordHash = new PasswordHasher<Employee>().HashPassword(admin, "12356Ab!");
            builder.Entity<Employee>().HasData(admin);

            return admin.Id;
        }

        private string SeedRole(ModelBuilder builder)
        {
            var admin = new IdentityRole
            {
                Name = "admin",
                Id = Guid.NewGuid().ToString()
            };
            admin.NormalizedName = admin.Name.ToUpper();
            builder.Entity<IdentityRole>().HasData(admin);
            return admin.Id;
        }

        private void SeedUserRole(ModelBuilder builder, string UserId, string RoleId)
        {
            var userRole = new IdentityUserRole<string>
            {
                UserId = UserId,
                RoleId = RoleId
            };
            builder.Entity<IdentityUserRole<string>>().HasData(userRole);
        }
    }
}