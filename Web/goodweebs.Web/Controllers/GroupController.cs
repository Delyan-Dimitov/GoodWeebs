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

        public IActionResult CreatePost(string id)
        {
            var model = new CreatePostInputModel { GroupId = id };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostInputModel model, string id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            model.GroupId = id;
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.groupService.CreatePostAsync(model, userId);

            return this.RedirectToAction("Group", new { Id = id });  // TODO change
        }

        public IActionResult Comment(string id)
        {
            var model = new CommentInputModel { PostId = id };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Comment(CommentInputModel model, string id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.groupService.CreateCommentAsync(model, userId, id);
            return this.RedirectToAction("Post",  new { id });
        }

        public async Task<IActionResult> GroupAsync(string id)
        {
            var model = await this.groupService.GetGroupByIdAsync(id);
            return this.View(model);
        }

        public async Task<IActionResult> All()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.groupService.GetUsersGroupsAsync(userId);
            return this.View(model);
        }

        public async Task<IActionResult> PostAsync(string id)
        {
            var model = await this.groupService.GetPostByIdAsync(id);

            return this.View(model);
        }
    }
}
