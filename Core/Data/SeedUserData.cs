

using Microsoft.AspNetCore.Identity;
using Models.Identity;

namespace Core.Data
{
    public class SeedUserData
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName ="Admin",
                    Email="Admin@test.com",
                    UserName="Admin@test.com"
                };
                await userManager.CreateAsync(user,"Ad@1234");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
