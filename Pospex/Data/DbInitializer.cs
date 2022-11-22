using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pospex.Models;

namespace Pospex.Data
{
    public class DbInitializer
    {
        public static async void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.Migrate();

            var adminEmail = "admin@gmail.com";
            var password = "1qazXSW@";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser { Email = adminEmail, UserName = adminEmail, EmailConfirmed = true};
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
