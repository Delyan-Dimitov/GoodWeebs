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
    using GoodWeebs.Data.Models.MappingTables;

    public class UpdateService : IUpdateService
    {
        private readonly IDeletableEntityRepository<Update> updateRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<Group> groupRepo;
        private readonly IDeletableEntityRepository<Friends> friendsRepo;
        private readonly IDeletableEntityRepository<Anime> animeRepo;
        private readonly IDeletableEntityRepository<Manga> mangaRepo;
        private readonly IDeletableEntityRepository<UsersGroups> usersGroupsRepo;

        public UpdateService(
            IDeletableEntityRepository<Update> updateRepo,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<Group> groupRepo,
            IDeletableEntityRepository<Friends> friendsRepo,
            IDeletableEntityRepository<Anime> animeRepo,
            IDeletableEntityRepository<Manga> mangaRepo,
            IDeletableEntityRepository<UsersGroups> usersGroupsRepo)
        {
            this.updateRepo = updateRepo;
            this.userManager = userManager;
            this.groupRepo = groupRepo;
            this.friendsRepo = friendsRepo;
            this.animeRepo = animeRepo;
            this.mangaRepo = mangaRepo;
            this.usersGroupsRepo = usersGroupsRepo;
        }

        public async Task CreateSeriesUpdate(string userId, int seriesId, int seriesType, string contentType)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var contentTitle = seriesType == 1 ?
                this.animeRepo.AllAsNoTracking().Where(x => x.Id == seriesId).FirstOrDefault().Title :
                this.mangaRepo.AllAsNoTracking().Where(x => x.Id == seriesId).FirstOrDefault().Title;

            var update = new Update
            {
                ContentId = seriesId,
                User = user,
                Type = seriesType,
                UpdateContent = contentType,
                UserDisplayName = user.DisplayName,
                ContentTitle = contentTitle, // Do i need to have the content title?
            };

            await this.updateRepo.AddAsync(update);

            await this.updateRepo.SaveChangesAsync();

        }

        public async Task CreatePostUpdate(string userId, int postId, string groupId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var update = new Update
            {
                ContentId = postId,
                User = user,
                Type = 3,
                GroupId = groupId,
            };

            await this.updateRepo.AddAsync(update);
            await this.updateRepo.SaveChangesAsync();
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
                                    UserId = update.UserId,
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
                                    UserId = update.UserId,
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
                                    UserId = update.UserId,
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
                                    UserId = update.UserId,
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
                                    UserId = update.UserId,
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
                                    UserId = update.UserId,
                                    UserDisplayName = update.UserDisplayName,
                                });
                        }
                    }
                    else if (update.Type == 3)
                    {
                        var group = this.groupRepo.AllAsNoTracking().Where(x => x.Id == update.GroupId).FirstOrDefault();
                        updatesViewModel.PostUpdates.
                            Add(new PostUpdateViewModel
                            {
                                UserDisplayName = update.UserDisplayName,
                                Content = string.Format(PostUpdateViewModel.PostContentTemplate, update.UserDisplayName, update.UpdateContent, group.Name),
                                GroupName = group.Name,
                                PostId = update.ContentId,
                                UpdateId = update.Id,
                            });
                    }
                }
            }

            return updatesViewModel;

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
                    var friendId = friendship.MainUserId == userId ? friendship.FriendUserId : friendship.MainUserId;
                    var friendsUpdates = this.updateRepo.AllAsNoTracking().Where(x => x.UserId == friendId).ToList();
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

            var userGroups = this.usersGroupsRepo.AllAsNoTracking().Where(x => x.UserId == userId).ToList();
            var groups = new List<Group>();
            if (userGroups != null)
            {
                foreach (var userGroup in userGroups)
                {
                    var group = this.groupRepo.AllAsNoTracking().Where(x => x.Id == userGroup.GroupId).FirstOrDefault();
                    groups.Add(group);
                }
            }
            if (groups != null)
            {
                var groupsUpdates = new List<Update>();
                foreach (var group in groups)
                {
                    var groupUpdates = this.updateRepo.AllAsNoTracking().Where(x => x.GroupId == group.Id);
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
                updates = updates.Take(5).ToList();
            }
            else
            {
                updates = updates.Take(updateCount).ToList();
            }
            return updates;
        }


    }
}
