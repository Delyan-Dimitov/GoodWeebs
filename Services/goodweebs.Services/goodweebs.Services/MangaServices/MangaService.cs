namespace GoodWeebs.Services.GoodWeebs.Services.MangaServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Entities;
    using Entities.Maps;
    using global::GoodWeebs.Data;
    using global::GoodWeebs.Data.Common.Repositories;
    using global::GoodWeebs.Web.ViewModels.MangaViewModels;
    using Microsoft.EntityFrameworkCore;

    public class MangaService : IMangaService
    {
        private readonly IDeletableEntityRepository<Manga> mangaRepo;
        private readonly ApplicationDbContext dbContext;

        public MangaService(IDeletableEntityRepository<Manga> mangaRepo, ApplicationDbContext dbContext)
        {
            this.mangaRepo = mangaRepo;
            this.dbContext = dbContext;
        }

        public IEnumerable<MangaInListViewModel> GetAll(int page, int itemsPerPage)
        {
            var mangas = this.mangaRepo.AllAsNoTracking()
              .OrderBy(x => x.Id)
              .Skip((page - 1) * itemsPerPage)
              .Take(itemsPerPage)
                .Select(x => new MangaInListViewModel
                {
                    MangaId = x.Id,
                    Title = x.Title,
                    Genre = x.Genres,
                    PictureUrl = x.PictureUrl,
                    Synposis = x.Synopsis,
                }).ToList();
            return mangas;
        }

        public IEnumerable<MangaInListViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public MangaViewModel GetInfoById(int id)
        {
            var manga = this.mangaRepo.AllAsNoTracking().Where(x => x.Id == id).Select(x => new MangaViewModel
            {
                Title = x.Title,
                Authors = x.Authors,
                Synopsis = x.Synopsis,
                Volumes = x.Volumes,
                Chapters = x.Chapters,
                Published = x.Published,
                PictureUrl = x.PictureUrl,
                Genres = x.Genres,
            }).ToList();
            return manga[0];
        }

        public async Task<IEnumerable<Manga>> GetTopGlobalAsync(int amount)
        {
            List<Manga> query = from p in this.dbContext.Set<ReadMap>()
                        group p by p.MangaId into g
                        orderby g.Count()
                        select new
                        {
                            g.Key,
                            Count = g.Count(),
                        }.ToList();
            query.Take(amount).ToList();

            List<Manga> topManga = new List<Manga>();

            foreach (var item in query)
            {
                 topManga.Add(await this.dbContext.Mangas.FirstOrDefaultAsync(x => x.Id == item.Key));
            }

            return topManga;
        }
    }
}
