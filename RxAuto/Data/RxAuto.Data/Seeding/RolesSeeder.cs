namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Seeds <c>roles</c> to <see cref="IdentityRole"/> entity in database using <see cref="ApplicationDbContext"/>.
    /// </summary>
    public class RolesSeeder : ISeeder
    {
        private RoleManager<ApplicationRole> roleManager;

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            this.roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            await SeedRoleAsync(roleManager, "Administrator");
            await SeedRoleAsync(roleManager, "User");
            await SeedRoleAsync(roleManager, "Guest");
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            ApplicationRole role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                IdentityResult result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
