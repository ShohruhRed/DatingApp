using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            IQueryable<AppUser> appUsers;

            IdentityResult result; 
            

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();

                await userManager.CreateAsync(user, "seedPassword");

                result  = await userManager.CreateAsync(user);

                if (!result.Succeeded)
                {
                    foreach (IdentityError error in result.Errors)
                        Console.WriteLine($"Oops! {error.Description} ({error.Code})");
                }
                    
            }           
        }
    }
}
