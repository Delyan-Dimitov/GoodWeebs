namespace GoodWeebs.Services.Data.GoodWeebsDataServices.GroupServices
{
    using System.Linq;
    using System.Threading.Tasks;
    using Ganss.XSS;
    using global::GoodWeebs.Data.Common.Repositories;
    using global::GoodWeebs.Data.Models;
    using global::GoodWeebs.Data.Models.MappingTables;
    using global::GoodWeebs.Web.ViewModels.GroupViewModel;
    using Microsoft.AspNetCore.Identity;

    public class GroupService : IGroupService
    {
        private readonly IDeletableEntityRepository<Group> groupRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<UsersGroups> usersGroupsRepo;
        private readonly IDeletableEntityRepository<Post> postRepo;
        private readonly IDeletableEntityRepository<Comment> commentRepo;
        private readonly IHtmlSanitizer htmlSanitizer;

        public GroupService(
            IDeletableEntityRepository<Group> groupRepo,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<UsersGroups> usersGroupsRepo,
            IDeletableEntityRepository<Post> postRepo,
            IDeletableEntityRepository<Comment> commentRepo,
            IHtmlSanitizer htmlSanitizer)
        {
            this.groupRepo = groupRepo;
            this.userManager = userManager;
            this.usersGroupsRepo = usersGroupsRepo;
            this.postRepo = postRepo;
            this.commentRepo = commentRepo;
            this.htmlSanitizer = htmlSanitizer;
        }

        public async Task CreateGroupAsync(CreateGroupInputModel model, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var newGroup = new Group
            {
                Admin = user,
                Name = model.Name,
                Description = model.Description,
                Picture = model.Picture,
            };

            await this.groupRepo.AddAsync(newGroup);
            await this.groupRepo.SaveChangesAsync();
        }

        public async Task<GroupListViewModel> GetUsersGroupsAsync(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var model = new GroupListViewModel();
            var usersGroups = this.usersGroupsRepo.AllAsNoTracking().Where(x => x.User == user).Select(x => x.Group).ToList();
            var sanitizer = new HtmlSanitizer();
            if (usersGroups.Count() != 0)
            {

                foreach (var group in usersGroups)
                {
                    model.Groups.Add(new GroupInListViewModel
                    {
                        Name = group.Name,
                        Description = sanitizer.Sanitize(group.Description),
                        Id = group.Id,
                        Picture = group.Picture,
                    });
                }
            }
            else
            {
                var adminGroup = this.groupRepo.AllAsNoTracking().Where(x => x.AdminId == userId).FirstOrDefault();
                if (adminGroup != null)
                {
                    model.Groups.Add(new GroupInListViewModel
                    {
                        Name = adminGroup.Name,
                        Description = sanitizer.Sanitize(adminGroup.Description),
                        Id = adminGroup.Id,
                        Picture = adminGroup.Picture,
                    });
                }
            }


            return model;
        }

        public async Task<GroupViewModel> GetGroupByIdAsync(string groupId)
        {
            var group = this.groupRepo
                .AllAsNoTracking()
                .Where(x => x.Id == groupId)
                .FirstOrDefault();

            var model = new GroupViewModel { Id = group.Id, Admin = group.Admin, Description = this.htmlSanitizer.Sanitize(group.Description), Name = group.Name, Picture = group.Picture };
            var posts = this.postRepo
                .AllAsNoTracking()
                .Where(x => x.GroupId == groupId)
                .ToList().
                OrderByDescending(x => x.CreatedOn);

            foreach (var post in posts)
            {
                var poster = await this.userManager.FindByIdAsync(post.PosterId);
                model.Posts.Add(new PostInListViewModel { Title = post.Title, PosterDisplayName = poster.DisplayName, PostId = post.Id, PosterId = post.PosterId });
            }

            return model;
        }

        public async Task CreatePostAsync(CreatePostInputModel model, string submitterId)
        {
            var poster = await this.userManager.FindByIdAsync(submitterId);
            var group = this.groupRepo.AllAsNoTracking().Where(x => x.Id == model.GroupId).FirstOrDefault();
            var post = new Post { Poster = poster, Title = model.Title, Content = model.Content, GroupId = group.Id, PosterDisplayName = poster.DisplayName };
            await this.postRepo.AddAsync(post);
            await this.postRepo.SaveChangesAsync();
        }

        public async Task CreateCommentAsync(CommentInputModel model, string commenterId, string postId)
        {
            var commenter = await this.userManager.FindByIdAsync(commenterId);
            var post = this.postRepo.AllAsNoTracking().Where(x => x.Id == postId).FirstOrDefault();
            var comment = new Comment
            {
                Content = model.Content,
                PostId = post.Id,
                CommenterId = commenterId,
            };
            await this.commentRepo.AddAsync(comment);
            await this.commentRepo.SaveChangesAsync();
        }

        public async Task<PostViewModel> GetPostByIdAsync(string postId)
        {

            var post = this.postRepo.AllAsNoTracking().Where(x => x.Id == postId).FirstOrDefault();
            var comments = this.commentRepo.AllAsNoTracking().Where(x => x.Post == post).ToList();
            var sanitizer = new HtmlSanitizer();
            var model = new PostViewModel
            {
                Title = post.Title,
                Content = sanitizer.Sanitize(post.Content),
                PosterId = post.PosterId,
                Id = post.Id,
            };
            if (comments.Count() > 0)
            {
                foreach (var comment in comments)
                {
                    var commenter = await this.userManager.FindByIdAsync(comment.CommenterId);
                    model.Comments.Add(new CommentViewModel { CommenterDisplayName = commenter.DisplayName, CommenterId = commenter.Id, Content = sanitizer.Sanitize(comment.Content) });
                }
            }
            return model;
        }

        public async Task AddUserToGroup(string userId, string groupId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var group = this.groupRepo.AllAsNoTracking().Where(x => x.Id == groupId).FirstOrDefault();
            var userGroup = new UsersGroups { User = user, Group = group };
            await this.usersGroupsRepo.AddAsync(userGroup);
            await this.usersGroupsRepo.SaveChangesAsync();
        }
    }
}
