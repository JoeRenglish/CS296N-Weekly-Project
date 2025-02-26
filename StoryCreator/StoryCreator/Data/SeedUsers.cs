using StoryCreator.Models;
using Microsoft.AspNetCore.Identity;

namespace StoryCreator.Data;

public class SeedUsers
{
    public static async Task CreateAdminUserAsync(IServiceProvider provider)
    {
        var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = provider.GetRequiredService<UserManager<AppUser>>();
        string username = "admin";
        string password = "A@m1n!123";
        string roleName = "Admin";

        if (await roleManager.FindByNameAsync(roleName) == null)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }

        AppUser user = new AppUser { UserName = username };
        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, roleName);
        }
    }
}