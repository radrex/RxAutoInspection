﻿namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using Microsoft.AspNetCore.Identity;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;

    public class UsersSeeder : ISeeder
    {
        private UserManager<ApplicationUser> userManager;

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            this.userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            await SeedUserAsync(userManager, "AdminUser", "123456", "admin@gmail.com", "Administrator");
            await SeedUserAsync(userManager, "GuestUser", "654321", "guest@gmail.com", "Guest");
            await SeedUserAsync(userManager, "NormalUser", "123456", "user@gmail.com", "User");
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, string username, string password, string email, string roleName)
        {
            ApplicationUser user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                user = new ApplicationUser(username);
                IdentityResult createUserResult = await userManager.CreateAsync(user, password);
                IdentityResult roleResult = await userManager.AddToRoleAsync(user, roleName);
                IdentityResult emailResult = await userManager.SetEmailAsync(user, email);

                string emailConfirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                IdentityResult emailConfirmationResult = await userManager.ConfirmEmailAsync(user, emailConfirmationToken);

                if (!createUserResult.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, createUserResult.Errors.Select(e => e.Description)));
                }

                if (!roleResult.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, roleResult.Errors.Select(e => e.Description)));
                }

                if (!emailResult.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, emailResult.Errors.Select(e => e.Description)));
                }

                if (!emailConfirmationResult.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, emailConfirmationResult.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
