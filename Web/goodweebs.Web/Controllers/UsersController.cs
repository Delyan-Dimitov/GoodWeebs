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

        public IActionResult Profile(string userId)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (myId == userId)
            {
                return this.RedirectToAction("Users/MyProfile");
            }

            var model = this.userService.GetUserById(userId);
            return this.View(model);
        }

        public IActionResult MyProfile()
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = this.userService.GetUserById(myId);
            return this.View(model);
        }

        public IActionResult FriendsList()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = this.userService.GetAllFriends(userId);
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
            return this.RedirectToAction($"Users/Profile/{id}");
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
            return this.Redirect("Users/MyProfile"); // TODO Make it redirect to friend request list
        }

        [HttpPost]
        public async Task<IActionResult> AddFriend(string adderId)
        {
            var addedId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.userService.AddFriend(adderId, addedId);
            return this.RedirectToAction("Users/MyProfile"); // TODO redirect to friends list
        }
    }
}
