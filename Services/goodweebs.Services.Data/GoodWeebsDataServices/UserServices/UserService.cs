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
            IDeletableEntityRepository<FriendRequest> friendRequestRepo
            )
        {
            this.userRepo = userRepo;
            this.friendsRepo = friendsRepo;
            this.userManager = userManager;
            this.friendRequestRepo = friendRequestRepo;
        }

        public async Task<ProfileViewModel> GetUserById(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var model = new ProfileViewModel { Id = user.Id, AvatarUrl = user.AvatarUrl, DisplayName = user.DisplayName };
            return model;

        }

        public async Task RequestFriend(string requesterId, string requesteeId)
        {
            Friends friendship = new Friends();
            if (this.FrindshipExists(requesterId, requesteeId))
            {
                friendship = this.friendsRepo.AllAsNoTrackingWithDeleted().First(x =>
                (x.FriendUserId == requesteeId && x.MainUserId == requesterId) |
                (x.FriendUserId == requesterId && x.MainUserId == requesteeId));
            }

            if (!this.FrindshipExists(requesterId, requesteeId) && !this.FrindshipExists(requesterId, requesteeId))
            {
                var requester = await this.userManager.FindByIdAsync(requesterId);
                var requestee = await this.userManager.FindByIdAsync(requesteeId);
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
                .Where(x =>
                (x.FriendUserId == addedId && x.MainUserId == adderId) |
                (x.FriendUserId == adderId && x.MainUserId == addedId)).FirstOrDefault();
            if (friends == null)
            {
                var adder = await this.userManager.FindByIdAsync(adderId);
                var added = await this.userManager.FindByIdAsync(addedId);
                var friend = new Friends { MainUser = adder, FriendUser = added };
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

        public bool FrindshipExists(string mainUserId, string secondUserId)
        {
            return this.friendsRepo
                 .AllAsNoTrackingWithDeleted()
                 .Any(x =>
                 (x.FriendUserId == secondUserId && x.MainUserId == mainUserId) |
                 (x.FriendUserId == mainUserId && x.MainUserId == secondUserId));
        }
        public bool FrindshipRequestExists(string mainUserId, string secondUserId)
        {
            return this.friendRequestRepo
                 .AllAsNoTrackingWithDeleted()
                 .Any(x =>
                 (x.RequesteeId == secondUserId && x.RequesterId == mainUserId) |
                 (x.RequesteeId == mainUserId && x.RequesterId == secondUserId));
        }

        public async Task<FriendsListViewModel> GetAllFriends(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var usersFriends = this.friendsRepo.AllAsNoTracking().Where(x => x.FriendUser == user | x.MainUser == user).ToList();
            FriendsListViewModel friends = new FriendsListViewModel();
            if (usersFriends == null)
            {
                return friends;
            }
            else
            {
                foreach (var friend in usersFriends)
                {
                    if (friend.MainUserId == userId)
                    {
                        var friendUser = await this.userManager.FindByIdAsync(friend.FriendUserId);
                        friends.Friends.Add(new ProfileViewModel { Id = friend.FriendUserId, AvatarUrl = friendUser.AvatarUrl, DisplayName = friendUser.DisplayName });

                    }
                    else if (friend.FriendUserId == userId)
                    {
                        var mainUser = await this.userManager.FindByIdAsync(friend.MainUserId);
                        friends.Friends.Add(new ProfileViewModel { Id = friend.MainUserId, AvatarUrl = mainUser.AvatarUrl, DisplayName = mainUser.DisplayName });

                    }
                }
            }


            return friends;
        }

        public async Task<FriendRequestListViewModel> GetAllFriendRequests(string userId)
        {
            var requests = this.friendRequestRepo.AllAsNoTracking().Where(x => x.RequesteeId == userId);
            FriendRequestListViewModel model = new FriendRequestListViewModel();
            if (requests == null)
            {
                return model;
            }
            else
            {
                foreach (var request in requests)
                {
                    var sender = await this.userManager.FindByIdAsync(request.RequesterId);
                    model.FriendRequests.Add(new FriendRequestViewModel { Id = request.Id, Sender = new ProfileViewModel { Id = sender.Id, AvatarUrl = sender.AvatarUrl, DisplayName = sender.DisplayName } });
                }
            }
            return model;
        }
    }
}
