using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using goodweebs.Data.Models;
using Goodweebs.Data.Models;
using Newtonsoft.Json;

namespace goodweebs.Data.Seeding
{
    public class AnimeSeeder : ISeeder
    {
        private const string Path = @"C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\wwwroot\anime-offline-database.json";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            if (dbContext.Animes.Any())
            {
                return;
            }
            string json = null;
            using (StreamReader r = new StreamReader(@"C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\wwwroot\anime-offline-database.json"))
            {
                json = r.ReadToEnd();
            }
            var animeDTOs = JsonConvert.DeserializeObject<AnimeDTO[]>(json);
            List<HelperAnime> helperAnime = new List<HelperAnime>();
            foreach (var aDto in animeDTOs)
            {
                var anime = new HelperAnime()
                {
                    Sources = string.Join(", ", aDto.Sources),

                    Title = aDto.Title,

                    Type = aDto.Type,

                    Episodes = aDto.Episodes,

                    Status = aDto.Status,

                    AnimeSeason = string.Join(", ", aDto.AnimeSeason),

                    Picture = aDto.Picture,

                    Thumbnail = aDto.Thumbnail,

                    Synonyms = string.Join(", ", aDto.Synonyms),

                    Relations = string.Join(", ", aDto.Relations),

                    Tags = string.Join(", ", aDto.Tags),
                };
                helperAnime.Add(anime);
            }
            dbContext.HelperAnimes.AddRange(helperAnime);
            dbContext.SaveChanges();
        }
    }
}

