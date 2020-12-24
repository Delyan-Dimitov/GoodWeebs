namespace GoodWeebs.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.GroupServices;
    using GoodWeebs.Web.ViewModels.GroupViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class GroupController : BaseController
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        public IActionResult CreateGroup()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupInputModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.groupService.CreateGroupAsync(model, userId);
            return this.View(); // TODO redirect somewhere
        }

        public IActionResult CreatePost()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostInputModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.groupService.CreatePostAsync(model, userId);

            return this.View();  // TODO change
        }

        public IActionResult CreateComment()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentInputModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.groupService.CreateCommentAsync(model, userId, model.PostId);
            return this.View();
        }

        public IActionResult Group(string groupId)
        {
            var model = this.groupService.GetGroupById(groupId);
            return this.View(model);
        }

        public async Task<IActionResult> MyGroups()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.groupService.GetUsersGroupsAsync(userId);
            return this.View(model);
        }

        public IActionResult Post(string postId)
        {
            var model = this.groupService.GetPostById(postId);

            return this.View(model);
        }
    }
}
