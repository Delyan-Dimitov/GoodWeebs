namespace GoodWeebs.Web.Controllers
{
    using GoodWeebs.Data.Models;
    using GoodWeebs.Services.GoodWeebs.Services.UserServices;
    using GoodWeebs.Web.ViewModels.UserViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Authorize]
    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> ProfileAsync(string id)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (myId == id)
            {
                return this.RedirectToAction("MyProfile");
            }
            var model = await this.userService.GetUserById(id);
            if (!this.userService.FrindshipExists(id, myId) && !this.userService.FrindshipRequestExists(id, myId))
            {
                model.CanRequestFriendship = true;
            }


            return this.View(model);
        }

        public async Task<IActionResult> MyProfileAsync()
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.userService.GetUserById(myId);
            return this.View(model);
        }
        public async Task<IActionResult> FriendsListAsync(string id)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.userService.GetAllFriends(id);
            if (myId == id)
            {
                model.MyProfile = true;
            }
            return this.View(model);
        }

        public async Task<IActionResult> FriendRequestsAsync()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.userService.GetAllFriendRequests(userId);
            return this.View(model);
        }

        public async Task<IActionResult> SendFriendRequest(string id)
        {
            var requesterId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.userService.RequestFriend(requesterId, id);
            return this.RedirectToAction("Profile", new { id });
        }

        public async Task<IActionResult> RemoveFriend(string id)
        {
            var removerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.userService.RemoveFriend(removerId, id);
            return this.RedirectToAction("MyProfile"); // TODO Make it return you to your friends list
        }

        public async Task<IActionResult> RejectFriendRequest(string id)
        {
            await this.userService.RejectFriendRequest(id);
            return this.Redirect("MyProfile"); // TODO Make it redirect to friend request list
        }

        public async Task<IActionResult> AddFriend(string id)
        {
            var addedId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.userService.AddFriend(id, addedId);
            return this.RedirectToAction("MyProfile"); // TODO redirect to friends list
        }
    }
}
