using Entities;
using Entities.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goodweebs.Data.Seeding
{
    public class WatchedSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            if (dbContext.Animes.Any())
            {
                return;
            }
            List<Anime> anime = new List<Anime>();
            anime.Add(new Anime { Title = "Naruto" });
            anime.Add(new Anime { Title = "Bleach" });
            anime.Add(new Anime { Title = "DBZ" });
            anime.Add(new Anime { Title = "Cory in The House" });
            dbContext.Animes.AddRange(anime);
            await dbContext.SaveChangesAsync();
            List<WatchedMap> map = new List<WatchedMap>();
            foreach (var user in dbContext.Users)
            {
                map.Add(new WatchedMap()
                {
                    User = user,
                    UserId = user.Id,
                    Anime = dbContext.Animes.FirstOrDefault(x => x.Title == "Naruto"),
                    AnimeId = dbContext.Animes.FirstOrDefault(x => x.Title == "Naruto").Id,
                });
                map.Add(new WatchedMap()
                {
                    User = user,
                    UserId = user.Id,
                    Anime = dbContext.Animes.FirstOrDefault(x => x.Title == "Bleach"),
                    AnimeId = dbContext.Animes.FirstOrDefault(x => x.Title == "Bleach").Id,
                });
                map.Add(new WatchedMap()
                {
                    User = user,
                    UserId = user.Id,
                    Anime = dbContext.Animes.FirstOrDefault(x => x.Title == "DBZ"),
                    AnimeId = dbContext.Animes.FirstOrDefault(x => x.Title == "DBZ").Id,
                });
                map.Add(new WatchedMap()
                {
                    User = user,
                    UserId = user.Id,
                    Anime = dbContext.Animes.FirstOrDefault(x => x.Title == "Cory in The House"),
                    AnimeId = dbContext.Animes.FirstOrDefault(x => x.Title == "Cory in the House").Id,
                });
            }
            dbContext.WatchedMaps.AddRange(map);
            await dbContext.SaveChangesAsync();
        }
    }
}