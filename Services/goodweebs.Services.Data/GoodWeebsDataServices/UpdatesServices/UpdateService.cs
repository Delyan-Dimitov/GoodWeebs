namespace GoodwWebs.Services.Data.GoodWeebsDataServices.UpdatesServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Entities;
    using GoodWeebs.Data.Common.Repositories;
    using GoodWeebs.Data.Models;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.UpdatesServices;
    using Microsoft.AspNetCore.Identity;
    using GoodWeebs.Web.ViewModels.UpdateViewModels;


    public class UpdateService : IUpdateService
    {
        private readonly IDeletableEntityRepository<Update> updateRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<Group> groupRepo;
        private readonly IDeletableEntityRepository<Friends> friendsRepo;

        public UpdateService(
            IDeletableEntityRepository<Update> updateRepo,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<Group> groupRepo,
            IDeletableEntityRepository<Friends> friendsRepo)
        {
            this.updateRepo = updateRepo;
            this.userManager = userManager;
            this.groupRepo = groupRepo;
            this.friendsRepo = friendsRepo;
        }

        public async Task CreateSeriesUpdate(string userId, int seriesId, int seriesType, string contentType)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var update = new Update();
            update.ContentId = seriesId;
            update.User = user;
            update.Type = seriesType;
            update.UpdateContent = contentType;

            await this.updateRepo.AddAsync(update);

        }

        public async Task CreatePostUpdate(string userId, int postId, int groupId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var update = new Update();
            update.ContentId = postId;
            update.User = user;
            update.Type = 3;
            update.GroupId = groupId;
            await this.updateRepo.AddAsync(update);

        }

        public async Task<UpdateListViewModel> GetRelevantUpdatesAsViewModelAsync(string userId)
        {
            var updates = await this.GetRelevantUpdates(userId);
            var updatesViewModel = new UpdateListViewModel();
            if (updates.Any())
            {
                foreach (var update in updates)
                {
                    if (update.Type == 1)
                    {
                        if (update.UpdateContent == "Watched")
                        {
                            updatesViewModel.SeriesUpdates.
                                Add(new SeriesUpdateViewModel
                                {
                                    SeriesId = update.ContentId,
                                    Content = string.Format(SeriesUpdateViewModel.WatchedContentString, update.UserDisplayName, update.ContentTitle),
                                    UpdateId = update.Id,
                                    UserDisplayName = update.UserDisplayName,
                                });
                        }
                        else if (update.UpdateContent == "Watching")
                        {
                            updatesViewModel.SeriesUpdates.
                                Add(new SeriesUpdateViewModel
                                {
                                    SeriesId = update.ContentId,
                                    Content = string.Format(SeriesUpdateViewModel.WatchingContentString, update.UserDisplayName, update.ContentTitle),
                                    UpdateId = update.Id,
                                    UserDisplayName = update.UserDisplayName,
                                });
                        }
                        else if (update.UpdateContent == "WantToWatch")
                        {
                            updatesViewModel.SeriesUpdates.
                                Add(new SeriesUpdateViewModel
                                {
                                    SeriesId = update.ContentId,
                                    Content = string.Format(SeriesUpdateViewModel.WantToWatchContentString, update.UserDisplayName, update.ContentTitle),
                                    UpdateId = update.Id,
                                    UserDisplayName = update.UserDisplayName,
                                });
                        }
                    }
                    else if (update.Type == 2)
                    {
                        if (update.UpdateContent == "Read")
                        {
                            updatesViewModel.SeriesUpdates.
                                Add(new SeriesUpdateViewModel
                                {
                                    SeriesId = update.ContentId,
                                    Content = string.Format(SeriesUpdateViewModel.ReadContentString, update.UserDisplayName, update.ContentTitle),
                                    UpdateId = update.Id,
                                    UserDisplayName = update.UserDisplayName,
                                });
                        }
                        else if (update.UpdateContent == "Reading")
                        {
                            updatesViewModel.SeriesUpdates.
                                Add(new SeriesUpdateViewModel
                                {
                                    SeriesId = update.ContentId,
                                    Content = string.Format(SeriesUpdateViewModel.ReadingContentString, update.UserDisplayName, update.ContentTitle),
                                    UpdateId = update.Id,
                                    UserDisplayName = update.UserDisplayName,
                                });
                        }
                        else if (update.UpdateContent == "WantToRead")
                        {
                            updatesViewModel.SeriesUpdates.
                                Add(new SeriesUpdateViewModel
                                {
                                    SeriesId = update.ContentId,
                                    Content = string.Format(SeriesUpdateViewModel.WantToReadContentString, update.UserDisplayName, update.ContentTitle),
                                    UpdateId = update.Id,
                                    UserDisplayName = update.UserDisplayName,
                                });
                        }
                    }
                    else if (update.Type == 3)
                    {

                    }
                }
            }

        }

        private async Task<ICollection<Update>> GetRelevantUpdates(string userId)
        {
            var updates = new List<Update>();
            var user = await this.userManager.FindByIdAsync(userId);
            var userFriends = this.friendsRepo.AllAsNoTracking().Where(x => x.MainUser == user || x.FriendUser == user).ToList();
            var friendUpdates = new List<Update>();
            if (userFriends != null)
            {
                foreach (var friendship in userFriends)
                {
                    var friend = friendship.MainUser == user ? friendship.FriendUser : friendship.MainUser;
                    var friendsUpdates = this.updateRepo.AllAsNoTracking().Where(x => x.User == friend).ToList();
                    if (friendsUpdates != null)
                    {
                        friendUpdates.AddRange(friendsUpdates);
                    }

                }

                if (friendUpdates != null)
                {
                    updates.AddRange(friendUpdates);
                }
            }

            var userGroups = this.groupRepo.AllAsNoTracking().Where(x => x.Users.Contains(user)).ToList();
            if (userGroups != null)
            {
                var groupsUpdates = new List<Update>();
                foreach (var group in userGroups)
                {
                    var groupUpdates = this.updateRepo.AllAsNoTracking().Where(x => x.Group == group);
                    if (groupUpdates != null)
                    {
                        groupsUpdates.AddRange(groupUpdates);
                    }
                }

                if (groupsUpdates != null)
                {
                    updates.AddRange(groupsUpdates);
                }
            }
            updates.OrderBy(x => x.CreatedOn);
            var updateCount = updates.Count();
            if (updateCount >= 5)
            {
                updates = (List<Update>)updates.Take(5);
            }
            else
            {
                updates = (List<Update>)updates.Take(updateCount);
            }
            return updates;
        }


    }
}
