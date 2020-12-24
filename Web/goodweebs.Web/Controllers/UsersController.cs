namespace GoodWeebs.Web.Controllers
{
    using GoodWeebs.Data.Models;
    using GoodWeebs.Services.GoodWeebs.Services.UserServices;
    using GoodWeebs.Web.ViewModels.UserViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
        }

        [Route("Users/Profile/{userId}")]
        public async Task<IActionResult> ProfileAsync(string userId)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (myId == userId)
            {
                return this.RedirectToAction("MyProfile");
            }

            var model = await this.userService.GetUserById(userId);
            return this.View(model);
        }

        public async Task<IActionResult> MyProfileAsync()
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.userService.GetUserById(myId);
            return this.View(model);
        }
        [Route("Users/FriendsList/{userId}")]
        public async Task<IActionResult> FriendsListAsync(string userId)
        {
            var model = await this.userService.GetAllFriends(userId);
            return this.View(model);
        }

        public IActionResult FriendRequests()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = this.userService.GetAllFriendRequests(userId);
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendFriendRequest(string id)
        {
            var requesterId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.userService.RequestFriend(requesterId, id);
            return this.RedirectToAction("Users/Profile", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFriend(string removedId)
        {
            var removerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.userService.RemoveFriend(removerId, removedId);
            return this.RedirectToAction("Users/MyProfile"); // TODO Make it return you to your friends list
        }

        [HttpPost]
        public async Task<IActionResult> RejectFriendRequest(string friendRequestId)
        {
            await this.userService.RejectFriendRequest(friendRequestId);
            return this.Redirect("Users/FriendRequests"); // TODO Make it redirect to friend request list
        }

        [HttpPost]
        public async Task<IActionResult> AddFriend(string adderId)
        {
            var addedId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.userService.AddFriend(adderId, addedId);
            return this.RedirectToAction("Users/FriendsList"); // TODO redirect to friends list
        }
    }
}
