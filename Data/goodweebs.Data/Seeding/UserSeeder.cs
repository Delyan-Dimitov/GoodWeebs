namespace GoodWeebs.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using GoodWeebs.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UserSeeder : ISeeder
    {
        private readonly IServiceProvider serviceProvider;

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (dbContext.Users.Any())
            {
                return;
            }

            var password = "password";
            ApplicationUser dido = new ApplicationUser() { DisplayName = "Dido", UserName = "dido@gmail.com", AvatarUrl = "https://i.pinimg.com/564x/92/c8/12/92c81213a6cc452cfbb8f6f26cc60b03.jpg", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(dido, password);

            ApplicationUser gosho = new ApplicationUser() { DisplayName = "Gosho", UserName = "gosho@gmail.com", AvatarUrl = "https://i1.sndcdn.com/avatars-SxAFif0TCVMygPfP-YEuXFQ-t500x500.jpg", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(gosho, password);

            ApplicationUser pesho = new ApplicationUser() { DisplayName = "Pesho", UserName = "stamat@gmail.com", AvatarUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZuSlnGTdVEeWef2t0uXmveQYd9WOfrFqMbg&usqp=CAU", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(pesho, password);

            ApplicationUser ivan = new ApplicationUser() { DisplayName = "Ivan", UserName = "Ivan@gmail.com", AvatarUrl = "https://64.media.tumblr.com/08ac8c6474b7f50186703ca5730f54f1/fc61f6558819902c-b1/s1280x1920/89455b2adffa6bfbc43b8c67cdf19166f427d354.png", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(ivan, password);

            ApplicationUser stoyan = new ApplicationUser() { DisplayName = "Stoyan", UserName = "Stoyan@gmail.com", AvatarUrl = "https://i.pinimg.com/originals/aa/ab/5b/aaab5b13d453b6e4d97b215ab7df7f47.jpg", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(stoyan, password);

            ApplicationUser stamat = new ApplicationUser() { DisplayName = "Stamat", UserName = "petar@gmail.com", AvatarUrl = "https://i.pinimg.com/originals/84/e5/39/84e539a77442ee7387586e5a6f87db88.jpg", LikesAnime = true, LikesManga = true, };
            await userManager.CreateAsync(stamat, password);

            var friend = new Friends { MainUser = dido, FriendUser = gosho };
            var friend2 = new Friends { MainUser = dido, FriendUser = stamat };
            var friend3 = new Friends { MainUser = dido, FriendUser = stoyan };
            var friend4 = new Friends { MainUser = dido, FriendUser = ivan };
            dbContext.Friends.Add(friend);
            dbContext.Friends.Add(friend2);
            dbContext.Friends.Add(friend3);
            dbContext.Friends.Add(friend4);
            dbContext.SaveChanges();

        }
    }
}