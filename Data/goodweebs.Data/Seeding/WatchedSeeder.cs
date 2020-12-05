namespace GoodWeebs.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Entities.Maps;
    using Microsoft.EntityFrameworkCore;

    public class WatchedSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.WatchedMaps.Any())
            {
                return;
            }

            List<WatchedMap> map = new List<WatchedMap>();
            foreach (var user in dbContext.Users)
            {
                map.Add(new WatchedMap()
                {
                    User = user,
                    UserId = user.Id,
                    Anime = dbContext.Animes.FirstOrDefault(x => EF.Functions.Like(x.Title, "%Naruto%")),
                    AnimeId = dbContext.Animes.FirstOrDefault(x => EF.Functions.Like(x.Title, "%Naruto%")).Id,
                });
                map.Add(new WatchedMap()
                {
                    User = user,
                    UserId = user.Id,
                    Anime = dbContext.Animes.FirstOrDefault(x => EF.Functions.Like(x.Title, "%Bleach%")),
                    AnimeId = dbContext.Animes.FirstOrDefault(x => EF.Functions.Like(x.Title, "%Bleach%")).Id,
                });
                map.Add(new WatchedMap()
                {
                    User = user,
                    UserId = user.Id,
                    Anime = dbContext.Animes.FirstOrDefault(x => EF.Functions.Like(x.Title, "%Trigun%")),
                    AnimeId = dbContext.Animes.FirstOrDefault(x => EF.Functions.Like(x.Title, "%Trigun%")).Id,
                });
                map.Add(new WatchedMap()
                {
                    User = user,
                    UserId = user.Id,
                    Anime = dbContext.Animes.FirstOrDefault(x => EF.Functions.Like(x.Title, "%Coboy Bebop%")),
                    AnimeId = dbContext.Animes.FirstOrDefault(x => EF.Functions.Like(x.Title, "%Cowboy Bebop%")).Id,
                });
            }

            dbContext.WatchedMaps.AddRange(map);
            await dbContext.SaveChangesAsync();
        }
    }
}
