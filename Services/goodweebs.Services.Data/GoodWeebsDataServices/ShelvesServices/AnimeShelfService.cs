namespace GoodWeebs.Services.Data.GoodWeebsDataServices.ShelvesServices
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Entities;
    using Entities.Maps;
    using global::GoodWeebs.Data.Common.Repositories;
    using global::GoodWeebs.Data.Models;

    public class AnimeShelfService : IAnimeShelfService
    {
        private readonly IDeletableEntityRepository<CurrentlyWatchingMap> watchingRepo;
        private readonly IDeletableEntityRepository<WatchedMap> watchedRepo;
        private readonly IDeletableEntityRepository<WantToWatchMap> wantRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;
        private readonly IDeletableEntityRepository<Anime> animeRepo;

        public AnimeShelfService(
            IDeletableEntityRepository<CurrentlyWatchingMap> watchingRepo,
            IDeletableEntityRepository<WatchedMap> watchedRepo,
            IDeletableEntityRepository<WantToWatchMap> wantRepo,
            IDeletableEntityRepository<ApplicationUser> userRepo,
            IDeletableEntityRepository<Anime> animeRepo)
        {
            this.watchingRepo = watchingRepo;
            this.watchedRepo = watchedRepo;
            this.wantRepo = wantRepo;
            this.userRepo = userRepo;
            this.animeRepo = animeRepo;
        }

        public IDeletableEntityRepository<CurrentlyWatchingMap> WatchingRepo => watchingRepo;

        public async Task AddToWantToWatch(string userId, int animeId)
        {
            if (!this.IsInWant(userId, animeId) &&
                !this.IsInWatched(userId, animeId) &&
                !this.IsInWant(userId, animeId))
            {
                var user = this.userRepo.AllAsNoTracking().First(x => x.Id == userId);
                var anime = this.animeRepo.AllAsNoTracking().First(x => x.Id == animeId);

                await this.wantRepo.AddAsync(new WantToWatchMap { User = user, Anime = anime, UserId = userId, AnimeId = animeId });
                await this.wantRepo.SaveChangesAsync();
            }
        } 

        public async Task AddToWatched(string userId, int animeId)
        {
            var user = this.userRepo.AllAsNoTracking().First(x => x.Id == userId);
            var anime = this.animeRepo.AllAsNoTracking().First(x => x.Id == animeId);

            if (this.IsInWant(userId, animeId))
            {
                var toDelete = this.wantRepo.AllAsNoTracking().First(x => x.UserId == userId && x.AnimeId == animeId);
                this.wantRepo.Delete(toDelete);
                await this.wantRepo.SaveChangesAsync();
                await this.watchedRepo.AddAsync(new WatchedMap { User = user, Anime = anime });
                await this.watchedRepo.SaveChangesAsync();
            }
            else if (this.IsInWatched(userId, animeId))
            {
                var toDelete = this.WatchingRepo.AllAsNoTracking().First(x => x.UserId == userId && x.AnimeId == animeId);
                this.WatchingRepo.Delete(toDelete);
                await this.watchingRepo.SaveChangesAsync();
                await this.watchedRepo.AddAsync(new WatchedMap { User = user, Anime = anime });
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
            var user = this.userRepo.AllAsNoTracking().First(x => x.Id == userId);
            var anime = this.animeRepo.AllAsNoTracking().First(x => x.Id == animeId);

            if (this.IsInWant(userId, animeId))
            {
                var toDelete = this.wantRepo.AllAsNoTracking().First(x => x.UserId == userId && x.AnimeId == animeId);
                this.wantRepo.Delete(toDelete);
                await this.wantRepo.SaveChangesAsync();
                await this.watchingRepo.AddAsync(new CurrentlyWatchingMap { User = user, Anime = anime });
            }

            if (!this.IsInWatched(userId,animeId) && !this.IsInWant(userId, animeId) && !this.IsInWatching(userId, animeId))
            {
                await this.watchingRepo.AddAsync(new CurrentlyWatchingMap { User = user, Anime = anime });
                await this.watchingRepo.SaveChangesAsync();
            }
        }

        public Task RemoveFromWantToWatch(string userId, int animeId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromWatched(string userId, int animeId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromWatching(string userId, int animeId)
        {
            throw new NotImplementedException();
        }

        private bool IsInWatching(string userId, int animeId) => this.watchingRepo.AllAsNoTracking().Any(x => x.UserId == userId && x.AnimeId == animeId);

        private bool IsInWatched(string userId, int animeId) => this.watchedRepo.AllAsNoTracking().Any(x => x.UserId == userId && x.AnimeId == animeId);

        private bool IsInWant(string userId, int animeId) => this.wantRepo.AllAsNoTracking().Any(x => x.UserId == userId && x.AnimeId == animeId);
    }
}
