namespace GoodWeebs.Services.GoodWeebs.Services.MangaServices
{
    using System.Collections.Generic;
    using System.Linq;
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

        public IEnumerable<MangaViewModel> GetSimilar(int id, int amount)
        {
            var manga = this.GetInfoById(id);
            var genres = manga.Genres.Split(", ").ToList();
            var vaguelySimilar = new List<MangaViewModel>();
            foreach (var genre in genres)
            {
                vaguelySimilar.AddRange(this.mangaRepo
                    .AllAsNoTracking()
                    .Where(x => x.Genres.Contains(genre) && x.Id != id)
                    .Select(x => new MangaViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Synopsis = x.Synopsis,
                        PictureUrl = x.PictureUrl,
                    }).ToList());

            }

            var bestMatches = this.GetBestHits(genres, vaguelySimilar, amount); // Linter made me put "THIS"
            return bestMatches;
        }

        public IEnumerable<MangaViewModel> GetBestHits(IEnumerable<string> targets, IEnumerable<MangaViewModel> collection, int amount)
        {
            var result = new List<MangaViewModel>();
            var leaderBoard = new Dictionary<MangaViewModel, int>();
            foreach (var item in collection)
            {
                var hits = 0;
                foreach (var target in targets)
                {
                    if (item.Genres.Contains(target))
                    {
                        hits++;
                    }
                }

                leaderBoard.Add(item, hits);
            }

            var leaderBoardSorted = leaderBoard.OrderByDescending(x => x.Value);
            result.AddRange(leaderBoard.Keys.Take(amount));

            return result;
        }

        public async Task<IEnumerable<MangaViewModel>> GetTopGlobalAsync(int amount)
        {
            var query = from p in this.dbContext.Set<ReadMap>()
                        group p by p.MangaId into g
                        orderby g.Count()
                        select new
                        {
                            g.Key,
                            Count = g.Count(),
                        };
            query.Take(amount).ToList();

            List<Manga> topManga = new List<Manga>();

            foreach (var item in query)
            {
                topManga.Add(await this.dbContext.Mangas.FirstOrDefaultAsync(x => x.Id == item.Key));
            }

            return this.GetViewModels(topManga);
        }

        public IEnumerable<MangaViewModel> GetViewModels(IEnumerable<Manga> mangas)
        {
            var mangaViewModels = new List<MangaViewModel>();
            foreach (var manga in mangas)
            {
                mangaViewModels.Add(new MangaViewModel()
                {
                    Title = manga.Title,
                    Status = manga.Status,
                    Synopsis = manga.Synopsis,
                    Chapters = manga.Chapters,
                    Volumes = manga.Volumes,
                    PictureUrl = manga.PictureUrl,
                    Authors = manga.PictureUrl,
                    Genres = manga.Genres,
                    Published = manga.Published,
                    Type = manga.Type,
                    Id = manga.Id,
                });
            }

            return mangaViewModels;
        }

        public int GetCount() => this.mangaRepo.AllAsNoTracking().Count();
    }
}
