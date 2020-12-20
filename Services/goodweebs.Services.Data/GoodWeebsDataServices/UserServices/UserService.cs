namespace GoodWeebs.Services.GoodWeebs.Services.UserServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Entities;
    using global::GoodWeebs.Data.Common.Repositories;
    using global::GoodWeebs.Data.Models;
    using global::GoodWeebs.Web.ViewModels.UserViewModels;
    using Microsoft.AspNetCore.Identity;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;
        private readonly IDeletableEntityRepository<Friends> friendsRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<FriendRequest> friendRequestRepo;

        public UserService(
            IDeletableEntityRepository<ApplicationUser> userRepo,
            IDeletableEntityRepository<Friends> friendsRepo,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<FriendRequest> friendRequestRepo)
        {
            this.userRepo = userRepo;
            this.friendsRepo = friendsRepo;
            this.userManager = userManager;
            this.friendRequestRepo = friendRequestRepo;
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

        public ProfileViewModel GetUserById(string userId)
        {
            var user = this.userRepo.AllAsNoTracking().First(x => x.Id == userId);
            var model = new ProfileViewModel { Id = user.Id, AvatarUrl = user.AvatarUrl, DisplayName = user.DisplayName};
            return model;

        }

        public async Task RequestFriend(string requesterId, string requesteeId)
        {
            Friends friendship = null;
            if (this.FrindshipExists(requesterId, requesteeId))
            {
                friendship = this.friendsRepo.AllAsNoTrackingWithDeleted().First(x =>
                (x.FriendUserId == requesteeId && x.MainUserId == requesterId) |
                (x.FriendUserId == requesterId && x.MainUserId == requesteeId));
            }

            if (!this.FrindshipExists(requesterId, requesteeId) || (this.FrindshipExists(requesterId, requesteeId) && friendship.IsDeleted))
            {
                var requester = this.userRepo.AllAsNoTracking().First(x => x.Id == requesterId);
                var requestee = this.userRepo.AllAsNoTracking().First(x => x.Id == requesteeId);
                await this.friendRequestRepo.AddAsync(new FriendRequest { Requester = requester, Requestee = requestee });
                await this.friendRequestRepo.SaveChangesAsync();
            }
        }

        public async Task RejectFriendRequest(string friendRequestId)
        {
            if (this.friendRequestRepo.AllAsNoTracking().Any(x => x.Id == friendRequestId))
            {
                var friendRequest = this.friendRequestRepo.AllAsNoTracking().First(x => x.Id == friendRequestId);
                this.friendRequestRepo.HardDelete(friendRequest);
                await this.friendRequestRepo.SaveChangesAsync();
            }
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
                var friend = new Friends { MainUser = adder, FriendUser = added, MainUserId = adderId, FriendUserId = addedId };
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

        private bool FrindshipExists(string mainUserId, string secondUserId)
        {
            return this.friendsRepo
                 .AllAsNoTrackingWithDeleted()
                 .Any(x =>
                 (x.FriendUserId == secondUserId && x.MainUserId == mainUserId) |
                 (x.FriendUserId == mainUserId && x.MainUserId == secondUserId));
        }

        public FriendsListViewModel GetAllFriends(string userId)
        {
            var user = this.userRepo.AllAsNoTracking().First(x => x.Id == userId);
            var usersFriends = user.Friends;
            FriendsListViewModel friends = null;
            foreach (var friend in usersFriends)
            {
                if (friend.MainUserId != userId)
                {
                    friends.Friends.Add(new ProfileViewModel { Id = friend.MainUserId, AvatarUrl = friend.MainUser.AvatarUrl, DisplayName = friend.MainUser.DisplayName });
                }
                else if (friend.FriendUserId != userId)
                {
                    friends.Friends.Add(new ProfileViewModel { Id = friend.FriendUserId, AvatarUrl = friend.FriendUser.AvatarUrl, DisplayName = friend.FriendUser.DisplayName });
                }
            }

            return friends;
        }

        public List<FriendRequestViewModel> GetAllFriendRequests(string userId)
        {
            var requests = this.friendRequestRepo.AllAsNoTracking().Where(x => x.RequesteeId == userId);
            List<FriendRequestViewModel> model = null;
            foreach (var request in requests)
            {
                var sender = this.userRepo.AllAsNoTracking().First(x => x.Id == request.RequesterId);
                model.Add(new FriendRequestViewModel { Id = request.Id, Sender = new ProfileViewModel { Id = sender.Id, AvatarUrl = sender.AvatarUrl, DisplayName = sender.DisplayName } });

                // TODO cleanest code i have written in my life :)
            }

            return model;
        }
    }
}
