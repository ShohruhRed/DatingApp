using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
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

                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "seedPassword");

                await userManager.CreateAsync(user);                           
                    
            }           
        }
    }
}
