namespace GoodWeebs.Services.Data.GoodWeebsDataServices.ShelvesServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Entities;
    using Entities.Maps;
    using global::GoodWeebs.Data.Common.Repositories;
    using global::GoodWeebs.Data.Models;
    using global::GoodWeebs.Web.ViewModels.ShelfViewModels;
    using Microsoft.AspNetCore.Identity;

    public class AnimeShelfService : IAnimeShelfService
    {
        private readonly IDeletableEntityRepository<CurrentlyWatchingMap> watchingRepo;
        private readonly IDeletableEntityRepository<WatchedMap> watchedRepo;
        private readonly IDeletableEntityRepository<WantToWatchMap> wantRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;
        private readonly IDeletableEntityRepository<Anime> animeRepo;
        private readonly UserManager<ApplicationUser> userManager;

        public AnimeShelfService(
            IDeletableEntityRepository<CurrentlyWatchingMap> watchingRepo,
            IDeletableEntityRepository<WatchedMap> watchedRepo,
            IDeletableEntityRepository<WantToWatchMap> wantRepo,
            IDeletableEntityRepository<ApplicationUser> userRepo,
            IDeletableEntityRepository<Anime> animeRepo,
            UserManager<ApplicationUser> userManager)
        {
            this.watchingRepo = watchingRepo;
            this.watchedRepo = watchedRepo;
            this.wantRepo = wantRepo;
            this.userRepo = userRepo;
            this.animeRepo = animeRepo;
            this.userManager = userManager;
        }


        public async Task AddToWantToWatch(string userId, int animeId)
        {
            if (!this.IsInWant(userId, animeId) &&
                !this.IsInWatched(userId, animeId) &&
                !this.IsInWant(userId, animeId))
            {
                var user = await this.userManager.FindByIdAsync(userId);
                var anime = this.animeRepo.AllAsNoTracking().First(x => x.Id == animeId);

                await this.wantRepo.AddAsync(new WantToWatchMap { User = user, Anime = anime, UserId = userId, AnimeId = animeId });
                await this.wantRepo.SaveChangesAsync();
            }
        }

        public async Task AddToWatched(string userId, int animeId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var anime = this.animeRepo.All().Where(x => x.Id == animeId).FirstOrDefault();

            if (this.IsInWant(userId, animeId))
            {
                var toDelete = this.wantRepo.AllAsNoTracking().FirstOrDefault(x => x.UserId == userId && x.AnimeId == animeId);
                this.wantRepo.Delete(toDelete);
                await this.wantRepo.SaveChangesAsync();
                await this.watchedRepo.AddAsync(new WatchedMap { User = user, Anime = anime });
                await this.watchedRepo.SaveChangesAsync();
            }
            else if (this.IsInWatching(userId, animeId))
            {
                var toDelete = this.watchingRepo.AllAsNoTracking().First(x => x.UserId == userId && x.AnimeId == animeId);
                this.watchingRepo.Delete(toDelete);
                await this.watchingRepo.SaveChangesAsync();
                await this.watchedRepo.AddAsync(new WatchedMap { UserId = userId, AnimeId = animeId });
                await this.watchedRepo.SaveChangesAsync();
            }
            else if (!this.IsInWatched(userId, animeId))
            {
                await this.watchedRepo.AddAsync(new WatchedMap { User = user, Anime = anime });
                await this.watchedRepo.SaveChangesAsync();
            }
        }

        public async Task AddToWatching(string userId, int animeId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var anime = this.animeRepo.AllAsNoTracking().First(x => x.Id == animeId);

            if (this.IsInWant(userId, animeId))
            {
                var toDelete = this.wantRepo.AllAsNoTracking().First(x => x.UserId == userId && x.AnimeId == animeId);
                this.wantRepo.Delete(toDelete);
                await this.wantRepo.SaveChangesAsync();
                await this.watchingRepo.AddAsync(new CurrentlyWatchingMap { User = user, Anime = anime });
            }

            if (!this.IsInWatched(userId, animeId) && !this.IsInWant(userId, animeId) && !this.IsInWatching(userId, animeId))
            {
                await this.watchingRepo.AddAsync(new CurrentlyWatchingMap { User = user, Anime = anime });
                await this.watchingRepo.SaveChangesAsync();
            }
        }

        public async Task RemoveFromWatched(string userId, int animeId)
        {
            if (this.IsInWatched(userId, animeId))
            {
                var toDelete = this.watchedRepo.AllAsNoTracking().First(x => x.UserId == userId && x.AnimeId == animeId);
                this.watchedRepo.Delete(toDelete);
                await this.watchedRepo.SaveChangesAsync();
            }
        }

        public async Task RemoveFromWatching(string userId, int animeId)
        {
            if (this.IsInWatching(userId, animeId))
            {
                var toDelete = this.watchingRepo.AllAsNoTracking().First(x => x.UserId == userId && x.AnimeId == animeId);
                this.watchingRepo.Delete(toDelete);
                await this.watchingRepo.SaveChangesAsync();
            }
        }

        public async Task RemoveFromWant(string userId, int animeId)
        {
            if (this.IsInWant(userId, animeId))
            {
                var toDelete = this.wantRepo.AllAsNoTracking().First(x => x.UserId == userId && x.AnimeId == animeId);
                this.wantRepo.Delete(toDelete);
                await this.wantRepo.SaveChangesAsync();
            }
        }

        public async Task<ShelfViewModel> GetWatched(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var model = new ShelfViewModel();
            var watched = this.watchedRepo.AllAsNoTracking().Where(x => x.UserId == userId).ToList();
            foreach (var map in watched)
            {
                var anime = this.animeRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == map.AnimeId);
                model.ShelfItems.Add(new ShelfItemVIewModel { Title = anime.Title, Id = anime.Id }); // TODO KYS
            }

            return model;
        }

        public async Task<ShelfViewModel> GetWatching(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var model = new ShelfViewModel();
            var watching = this.watchingRepo.AllAsNoTracking().Where(x => x.UserId == userId).ToList();
            foreach (var map in watching)
            {
                model.ShelfItems.Add(new ShelfItemVIewModel { Title = map.Anime.Title });
            }

            return model;
        }

        public async Task<ShelfViewModel> GetWantToWatch(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var model = new ShelfViewModel();
            var read = this.wantRepo.AllAsNoTracking().Where(x => x.UserId == userId).ToList();
            foreach (var map in read)
            {
                model.ShelfItems.Add(new ShelfItemVIewModel { Title = map.Anime.Title });
            }

            return model;
        }

        private bool IsInWatching(string userId, int animeId) => this.watchingRepo.AllAsNoTracking().Any(x => x.UserId == userId && x.AnimeId == animeId);

        private bool IsInWatched(string userId, int animeId) => this.watchedRepo.AllAsNoTracking().Any(x => x.UserId == userId && x.AnimeId == animeId);

        private bool IsInWant(string userId, int animeId) => this.wantRepo.AllAsNoTracking().Any(x => x.UserId == userId && x.AnimeId == animeId);
    }
}
