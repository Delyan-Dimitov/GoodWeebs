namespace GoodWeebs.Services.GoodWeebs.Services.UserServices
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using global::GoodWeebs.Data;
    using global::GoodWeebs.Data.Common.Repositories;
    using global::GoodWeebs.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;
        private readonly IDeletableEntityRepository<Friends> friendsRepo;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepo,
            IDeletableEntityRepository<Friends> friendsRepo,
            UserManager<ApplicationUser> userManager)
        {
            this.userRepo = userRepo;
            this.friendsRepo = friendsRepo;
            this.userManager = userManager;
        }

        public string GetUserAvatarByUsername(string username)
        {
            var url = this.userRepo.AllAsNoTracking().FirstOrDefault(x => x.UserName == username).AvatarUrl;
            return url;
        }

        public ApplicationUser GetUserByUserName(string username)
        {
            var user = this.userRepo.AllAsNoTracking().FirstOrDefault(x => x.UserName == username);
            return user;
        }

        public async Task AddFriend(string adderId, string addedId)
        {
            var friends = this.friendsRepo
                .AllAsNoTrackingWithDeleted()
                .First(x =>
                (x.FriendUserId == addedId && x.MainUserId == adderId) |
                (x.FriendUserId == adderId && x.MainUserId == addedId));
            if (friends == null)
            {
                var adder = this.userRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == addedId);
                var added = this.userRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == addedId);
                var friend = new Friends { MainUser = added, FriendUser = adder, MainUserId = adderId, FriendUserId = addedId };
                await this.friendsRepo.AddAsync(friend);
                await this.friendsRepo.SaveChangesAsync();
            }
            else if (friends.IsDeleted == true)
            {
                this.friendsRepo.Undelete(friends);
                await this.friendsRepo.SaveChangesAsync();
            }
        }

        public async Task RemoveFriend(string removerId, string removedId)
        {
            var friends = this.friendsRepo
                .AllAsNoTrackingWithDeleted()
                .First(x =>
                (x.FriendUserId == removedId && x.MainUserId == removerId) |
                (x.FriendUserId == removerId && x.MainUserId == removedId));
            if (friends != null)
            {
                if (friends.IsDeleted == false)
                {
                    this.friendsRepo.Delete(friends);
                    await this.friendsRepo.SaveChangesAsync();
                }
            }

        }
    }
}
