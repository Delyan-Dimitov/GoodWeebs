namespace GoodWeebs.Services.Data.GoodWeebsDataServices.ShelvesServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Entities;
    using Entities.Maps;
    using global::GoodWeebs.Data.Common.Repositories;
    using global::GoodWeebs.Data.Models;
    using global::GoodWeebs.Web.ViewModels.ShelfViewModels;
    using GoodwWebs.Services.Data.GoodWeebsDataServices.ShelvesServices;
    using Microsoft.AspNetCore.Identity;

    public class MangaShelfService : IMangaShelfService
    {
        private readonly IDeletableEntityRepository<ReadMap> readRepo;
        private readonly IDeletableEntityRepository<CurrentlyReadingMap> readingRepo;
        private readonly IDeletableEntityRepository<WantToReadMap> wantRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;
        private readonly IDeletableEntityRepository<Manga> mangaRepo;
        private readonly UserManager<ApplicationUser> userManager;

        public MangaShelfService(
            IDeletableEntityRepository<ReadMap> readRepo,
            IDeletableEntityRepository<CurrentlyReadingMap> readingRepo,
            IDeletableEntityRepository<WantToReadMap> wantRepo,
            IDeletableEntityRepository<ApplicationUser> userRepo,
            IDeletableEntityRepository<Manga> mangaRepo,
            UserManager<ApplicationUser> userManager)
        {
            this.readRepo = readRepo;
            this.readingRepo = readingRepo;
            this.wantRepo = wantRepo;
            this.userRepo = userRepo;
            this.mangaRepo = mangaRepo;
            this.userManager = userManager;
        }

        public async Task AddToWant(string userId, int mangaId)
        {
            if (!this.IsInWant(userId, mangaId) &&
                !this.IsInRead(userId, mangaId) &&
                !this.IsInWant(userId, mangaId))
            {
                var user = await this.userManager.FindByIdAsync(userId);
                var manga = this.mangaRepo.AllAsNoTracking().First(x => x.Id == mangaId);

                await this.wantRepo.AddAsync(new WantToReadMap { User = user, Manga = manga, UserId = userId, MangaId = mangaId });
                await this.wantRepo.SaveChangesAsync();
            }
        }

        public async Task AddToRead(string userId, int mangaId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var manga = this.mangaRepo.AllAsNoTracking().First(x => x.Id == mangaId);

            if (this.IsInWant(userId, mangaId))
            {
                var toDelete = this.wantRepo.AllAsNoTracking().First(x => x.UserId == userId && x.MangaId == mangaId);
                this.wantRepo.Delete(toDelete);
                await this.wantRepo.SaveChangesAsync();
                await this.readRepo.AddAsync(new ReadMap { User = user, Manga = manga });
                await this.readRepo.SaveChangesAsync();
            }
            else if (this.IsInRead(userId, mangaId))
            {
                var toDelete = this.readingRepo.AllAsNoTracking().First(x => x.UserId == userId && x.MangaId == mangaId);
                this.readingRepo.Delete(toDelete);
                await this.readingRepo.SaveChangesAsync();
                await this.readRepo.AddAsync(new ReadMap { User = user, Manga = manga });
                await this.readRepo.SaveChangesAsync();
            }
            else if (!this.IsInRead(userId, mangaId))
            {
                await this.readRepo.AddAsync(new ReadMap { User = user, Manga = manga });
                await this.readRepo.SaveChangesAsync();
            }
        }

        public async Task AddToReading(string userId, int mangaId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var manga = this.mangaRepo.AllAsNoTracking().First(x => x.Id == mangaId);

            if (this.IsInWant(userId, mangaId))
            {
                var toDelete = this.wantRepo.AllAsNoTracking().First(x => x.UserId == userId && x.MangaId == mangaId);
                this.wantRepo.Delete(toDelete);
                await this.wantRepo.SaveChangesAsync();
                await this.readingRepo.AddAsync(new CurrentlyReadingMap { User = user, Manga = manga });
            }

            if (!this.IsInRead(userId, mangaId) && !this.IsInWant(userId, mangaId) && !this.IsInReading(userId, mangaId))
            {
                await this.readingRepo.AddAsync(new CurrentlyReadingMap { User = user, Manga = manga });
                await this.readingRepo.SaveChangesAsync();
            }
        }

        public async Task RemoveFromRead(string userId, int mangaId)
        {
            if (this.IsInRead(userId, mangaId))
            {
                var toDelete = this.readRepo.AllAsNoTracking().First(x => x.UserId == userId && x.MangaId == mangaId);
                this.readRepo.Delete(toDelete);
                await this.readRepo.SaveChangesAsync();
            }
        }

        public async Task RemoveFromReading(string userId, int mangaId)
        {
            if (this.IsInReading(userId, mangaId))
            {
                var toDelete = this.readingRepo.AllAsNoTracking().First(x => x.UserId == userId && x.MangaId == mangaId);
                this.readingRepo.Delete(toDelete);
                await this.readingRepo.SaveChangesAsync();
            }
        }

        public async Task RemoveFromWant(string userId, int mangaId)
        {
            if (this.IsInWant(userId, mangaId))
            {
                var toDelete = this.wantRepo.AllAsNoTracking().First(x => x.UserId == userId && x.MangaId == mangaId);
                this.wantRepo.Delete(toDelete);
                await this.wantRepo.SaveChangesAsync();
            }
        }

        public async Task<ShelfViewModel> GetRead(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var model = new ShelfViewModel();
            model.ProfileId = userId;
            var read = this.readRepo.AllAsNoTracking().Where(x => x.UserId == userId).ToList();
            foreach (var map in read)
            {
                model.ShelfItems.Add(new ShelfItemVIewModel { Id = map.Id, Title = map.Manga.Title });
            }

            return model;
        }

        public async Task<ShelfViewModel> GetReading(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var model = new ShelfViewModel();
            model.ProfileId = userId;
            var read = this.readingRepo.AllAsNoTracking().Where(x => x.UserId == userId).ToList();
            foreach (var map in read)
            {
                model.ShelfItems.Add(new ShelfItemVIewModel { Id = map.Id, Title = map.Manga.Title });
            }

            return model;
        }

        public async Task<ShelfViewModel> GetWantToRead(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var model = new ShelfViewModel();
            model.ProfileId = userId;
            var read = this.wantRepo.AllAsNoTracking().Where(x => x.UserId == userId).ToList();
            foreach (var map in read)
            {
                model.ShelfItems.Add(new ShelfItemVIewModel { Id = map.Id, Title = map.Manga.Title });
            }

            return model;
        }

        private bool IsInReading(string userId, int mangaId) => this.readingRepo.AllAsNoTracking().Any(x => x.UserId == userId && x.MangaId == mangaId);

        private bool IsInRead(string userId, int mangaId) => this.readRepo.AllAsNoTracking().Any(x => x.UserId == userId && x.MangaId == mangaId);

        private bool IsInWant(string userId, int mangaId) => this.wantRepo.AllAsNoTracking().Any(x => x.UserId == userId && x.MangaId == mangaId);
    }
}
