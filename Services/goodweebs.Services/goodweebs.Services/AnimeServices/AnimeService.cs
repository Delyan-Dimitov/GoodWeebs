namespace GoodWeebs.Services.GoodWeebs.Services.AnimeServices
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    using Entities;
    using Entities.Maps;
    using global::GoodWeebs.Data;
    using global::GoodWeebs.Data.Common.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class AnimeService : IAnimeService

    {
        private readonly IRepository<Anime> animes;
        private readonly IRepository<WatchedMap> watchedMaps;
        private readonly ApplicationDbContext dbContext;

        public AnimeService(IRepository<Anime> anime, IRepository<WatchedMap> watchedMaps, ApplicationDbContext dbContext)
        {
            this.animes = anime;
            this.watchedMaps = watchedMaps;
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Entities.Anime>> GetAllAsync()
        {
            IQueryable<Anime> query =
                this.animes
                .All()
                .OrderBy(x => x.Id);

            return await query.Cast<Anime>().ToListAsync();
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
                topAnime.Add(this.dbContext.Animes.FirstOrDefault(x => x.Id == item.Key));
            }

            //var query = this.dbContext.Animes.Select(x => x.WatchedAnime).Max(bu => bu.Count);

            return topAnime;

            // TODO: Write it to get most popular anime  when you seed dummy users
        }
    }
}
