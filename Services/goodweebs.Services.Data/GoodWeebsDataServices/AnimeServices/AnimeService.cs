using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Entities;
using Entities.Maps;
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
        private readonly IRepository<AnimeSubmission> animeSubmissions;

        public AnimeService(IRepository<Anime> anime, IRepository<WatchedMap> watchedMaps, ApplicationDbContext dbContext, IRepository<AnimeSubmission> animeSubmissions)
        {
            this.animes = anime;
            this.watchedMaps = watchedMaps;
            this.dbContext = dbContext;
            this.animeSubmissions = animeSubmissions;
        }

        public IEnumerable<AnimeInListViewModel> GetAll(int page, int itemsPerPage = 12)
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
                      Synposis = x.Synopsis,
                  }).ToList();
            return animes;
        }

        public async Task<IEnumerable<Entities.Anime>> GetTopGlobalAsync(int amount)
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
                topAnime.Add(await this.dbContext.Animes.FirstOrDefaultAsync(x => x.Id == item.Key));
            }

            return topAnime;
        }

        public int GetCount() => this.animes.AllAsNoTracking().Count();

        public AnimeViewModel GetById(int id)
        {
            var anime = this.dbContext.Animes.Where(x => x.Id == id).Select(x => new AnimeViewModel
            {
                Title = x.Title,
                Studios = x.Studios,
                Synopsis = x.Synopsis,
                Rating = x.Rating,
                Episodes = x.Episodes.ToString(), 
                Duration = x.EpisodeDuration,
                Aired = x.Aired,
                PictureUrl = x.Picture,
                Genres = x.Genres,
            }).ToList();
            return anime[0];
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
