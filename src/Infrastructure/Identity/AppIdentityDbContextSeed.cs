using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(AppIdentityDbContext db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await db.Database.MigrateAsync();

            if (await roleManager.Roles.AnyAsync() || await userManager.Users.AnyAsync()) return;

            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.ADMINISTRATOR));

            var adminUser = new ApplicationUser()
            {
                Email = AuthorizationConstants.DEFAULT_ADMIN_USER,
                UserName = AuthorizationConstants.DEFAULT_ADMIN_USER,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);
            await userManager.AddToRoleAsync(adminUser, AuthorizationConstants.Roles.ADMINISTRATOR);

            var demoUser = new ApplicationUser()
            {
                Email = AuthorizationConstants.DEFAULT_DEMO_USER,
                UserName = AuthorizationConstants.DEFAULT_DEMO_USER,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(demoUser, AuthorizationConstants.DEFAULT_PASSWORD);
        }
    }
}
