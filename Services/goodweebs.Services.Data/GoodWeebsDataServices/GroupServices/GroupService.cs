namespace GoodWeebs.Services.Data.GoodWeebsDataServices.GroupServices
{
    using global::GoodWeebs.Data.Common.Repositories;
    using global::GoodWeebs.Data.Models;
    using global::GoodWeebs.Data.Models.MappingTables;
    using global::GoodWeebs.Web.ViewModels.GroupViewModel;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GroupService
    {
        private readonly IDeletableEntityRepository<Group> groupRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<UsersGroups> usersGroupsRepo;
        private readonly IDeletableEntityRepository<GroupsPosts> groupsPostsRepo;

        public GroupService(
            IDeletableEntityRepository<Group> groupRepo,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<UsersGroups> usersGroupsRepo,
            IDeletableEntityRepository<GroupsPosts> groupsPostsRepo)
        {
            this.groupRepo = groupRepo;
            this.userManager = userManager;
            this.usersGroupsRepo = usersGroupsRepo;
            this.groupsPostsRepo = groupsPostsRepo;
        }

        public async Task CreateGroupAsync(CreateGroupInputModel model, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var newGroup = new Group
            {
                Admin = user,
                Name = model.Name,
                Description = model.Description,
            };

            await this.groupRepo.AddAsync(newGroup);
            await this.groupRepo.SaveChangesAsync();
        }

        public async Task<GroupListViewModel> GetUsersGroupsAsync(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var model = new GroupListViewModel();
            var usersGroups = this.usersGroupsRepo.AllAsNoTracking().Where(x => x.User == user).Select(x => x.Group).ToList();
            if (usersGroups != null)
            {
                foreach (var group in usersGroups)
                {
                    model.Groups.Add(new GroupInListViewModel
                    {
                        Name = group.Name,
                        Description = group.Description,
                        Id = group.Id,
                    });
                }
            }

            return model;
        }

        public GroupViewModel GetGroupById(string groupId)
        {
            var group = this.groupRepo.AllAsNoTracking().Where(x => x.Id == groupId).FirstOrDefault();
            var model = new GroupViewModel { Id = group.Id, Admin = group.Admin, Description = group.Description, Name = group.Name };
            var posts = this.groupsPostsRepo.AllAsNoTracking().Where(x => x.Group == group).Select(x => x.Post).ToList();
            foreach (var post in posts)
            {
                model.Posts.Add(new PostInListViewModel { Title = post.Title, PosterDisplayName = post.Poster.DisplayName });
            }
            return model;
        }
    }
}
