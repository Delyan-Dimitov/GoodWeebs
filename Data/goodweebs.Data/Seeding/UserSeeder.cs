namespace GoodWeebs.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GoodWeebs.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

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
            ApplicationUser user = new ApplicationUser() { UserName = "fucku1@gmail.com", AvatarUrl = "https://static.wikia.nocookie.net/eroninja/images/b/be/Tobirama_Senju.png/revision/latest?cb=20180208004826", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(user, password);

        }
    }
}