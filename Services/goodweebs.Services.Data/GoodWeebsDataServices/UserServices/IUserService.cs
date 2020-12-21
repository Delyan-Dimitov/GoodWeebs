namespace GoodWeebs.Services.GoodWeebs.Services.UserServices
{
    using global::GoodWeebs.Data.Models;
    using global::GoodWeebs.Web.ViewModels.UserViewModels;
    using System.Threading.Tasks;

    public interface IUserService
    {
        string GetUserAvatarByUsername(string username);

        ApplicationUser GetUserByUserName(string username);

        ProfileViewModel GetUserById(string userId);

        Task RequestFriend(string requesterId, string requesteeId);

        Task RejectFriendRequest(string friendRequestId);

        Task AddFriend(string adderId, string addedId);

        Task RemoveFriend(string removerId, string removedId);

        FriendsListViewModel GetAllFriends(string userId);

        FriendRequestListViewModel GetAllFriendRequests(string userId);
    }
}
