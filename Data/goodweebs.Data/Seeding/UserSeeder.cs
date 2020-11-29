using GoodWeebs.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWeebs.Data.Seeding
{
    public class UserSeeder : ISeeder
    {
        private readonly ApplicationDbContext db;
        private readonly IServiceProvider serviceProvider;

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (dbContext.Users.Any())
            {
                return;
            }
            var password = "password";
            ApplicationUser user = new ApplicationUser() { UserName = "Guneto1", Email = "fucku1@gmail.com", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(user, password);

            ApplicationUser user1 = new ApplicationUser() { UserName = "Guneto2", Email = "fucku2@gmail.com", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(user1, password);

            ApplicationUser user2 = new ApplicationUser() { UserName = "Guneto3", Email = "fucku3@gmail.com", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(user2, password);

            ApplicationUser user3 = new ApplicationUser() { UserName = "Guneto4", Email = "fucku4@gmail.com", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(user3, password);

            ApplicationUser user4 = new ApplicationUser() { UserName = "Guneto5", Email = "fucku5@gmail.com", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(user4, password);

            ApplicationUser user5 = new ApplicationUser() { UserName = "Guneto6", Email = "fucku6@gmail.com", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(user5, password);

            ApplicationUser user6 = new ApplicationUser() { UserName = "Guneto7", Email = "fucku7@gmail.com", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(user6, password);

            ApplicationUser user7 = new ApplicationUser() { UserName = "Guneto8", Email = "fucku8@gmail.com", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(user7, password);

            ApplicationUser user8 = new ApplicationUser() { UserName = "Guneto9", Email = "fucku9@gmail.com", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(user8, password);
        }
    }
}
