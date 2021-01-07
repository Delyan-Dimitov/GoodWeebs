using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Entities;
using Entities.Maps;
using Ganss.XSS;
using global::GoodWeebs.Data.Common.Repositories;
using global::GoodWeebs.Data.Models;
using GoodWeebs.Data;
using GoodWeebs.Web.ViewModels.AnimeViewModels;
using Microsoft.EntityFrameworkCore;

namespace GoodWeebs.Services.GoodWeebs.Services.AnimeServices
{
    public class AnimeService : IAnimeService
    {
        private readonly IRepository<Anime> animes;
        private readonly IRepository<WatchedMap> watchedMaps;
        private readonly ApplicationDbContext dbContext;
        private readonly IDeletableEntityRepository<Anime> animeRepo;

        public AnimeService(IDeletableEntityRepository<Anime> anime, IDeletableEntityRepository<WatchedMap> watchedMaps, ApplicationDbContext dbContext)
        {
            this.animes = anime;
            this.watchedMaps = watchedMaps;
            this.dbContext = dbContext;
        }

        public ICollection<AnimeInListViewModel> GetAll(int page, int itemsPerPage = 12)
        {
            var animes = this.animes.AllAsNoTracking()
                .OrderBy(x => x.Id)

                .Skip((page - 1) * itemsPerPage)

                .Take(itemsPerPage)
                  .Select(x => new AnimeInListViewModel
                  {
                      AnimeId = x.Id,
                      Title = x.Title,
                      Genre = x.Genres,
                      PictureUrl = x.Picture,
                      Synopsis = x.Synopsis,
                  }).ToList();
            return animes;
        }

        public async Task<IEnumerable<AnimeInListViewModel>> GetTopGlobalAsync(int amount)
        {
            var query = from p in this.dbContext.Set<WatchedMap>()
                        group p by p.AnimeId into g
                        orderby g.Count()
                        select new
                        {
                            g.Key,
                            Count = g.Count(),
                        };
            query.Take(amount);

            List<Anime> topAnime = new List<Anime>();

            foreach (var item in query)
            {
                topAnime.Add(this.animes.AllAsNoTracking().FirstOrDefault(x => x.Id == item.Key));
            }
            var animesAsViewModel = new List<AnimeInListViewModel>();
            foreach (var item in topAnime)
            {
                animesAsViewModel.Add(new AnimeInListViewModel { Title = item.Title, AnimeId = item.Id, Genre = item.Genres, PictureUrl = item.Picture, Synopsis = item.Synopsis });
            }

            return animesAsViewModel;
        }

        public int GetCount() => this.animes.AllAsNoTracking().Count();

        public AnimeViewModel GetById(int id)
        {
            var sanitizer = new HtmlSanitizer();
            var anime = this.animes.AllAsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            var model = new AnimeViewModel
            {
                Title = anime.Title,
                Studios = anime.Studios,
                Synopsis = sanitizer.Sanitize( anime.Synopsis),
                Rating = anime.Rating,
                Episodes = anime.Episodes.ToString(),
                Duration = anime.EpisodeDuration,
                Aired = anime.Aired,
                PictureUrl = anime.Picture,
                Genres = anime.Genres,
            };
            return model;
        }

        public IEnumerable<AnimeViewModel> GetSimilar(int id, int amount)
        {

            var anime = this.GetById(id);
            var genres = anime.Genres.Split(", ").ToList();
            var vaguelySimilar = new List<AnimeViewModel>();
            foreach (var genre in genres)
            {
                vaguelySimilar.AddRange(this.animes
                    .AllAsNoTracking()
                    .Where(x => x.Genres.Contains(genre) && x.Id != id)
                    .Select(x => new AnimeViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Synopsis = x.Synopsis,
                        PictureUrl = x.Picture,
                    }).ToList());
            }

            var bestMatches = this.GetBestHits(genres, vaguelySimilar, amount);
            return bestMatches;
        }

        public IEnumerable<AnimeViewModel> GetBestHits(IEnumerable<string> targets, IEnumerable<AnimeViewModel> collection, int amount)
        {
            var result = new List<AnimeViewModel>();
            var leaderBoard = new Dictionary<AnimeViewModel, int>();
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
    }
}
