namespace GoodWeebs.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Entities;
    using GoodWeebs.Data.Models;
    using Newtonsoft.Json;

    public class AnimeSeeder : ISeeder
    {
        private const string Path = @"C:\Users\gunex\Desktop\GoodWeebs\Web\GoodWeebs.Web\wwwroot\anime-offline-database.json";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            if (dbContext.Animes.Any())
            {
                return;
            }
            string json = null;
            using (StreamReader r = new StreamReader(@"C:\Users\gunex\Desktop\GoodWeebs\Web\GoodWeebs.Web\wwwroot\final.json"))
            {
                json = r.ReadToEnd();
            }
            var animeDTOs = JsonConvert.DeserializeObject<AnimeDTO[]>(json);
            List<Anime> animes = new List<Anime>();
            foreach (AnimeDTO aDto in animeDTOs)
            {
                var anime = new Anime()
                {
                    Title = aDto.Title,

                    Type = aDto.Type,

                    Episodes = aDto.Episodes,

                    Status = aDto.Status,

                    Aired = aDto.Aired,

                    Picture = aDto.Picture,

                    Synonyms = string.Join(", ", aDto.Synonyms),

                    Genres = string.Join(", ", aDto.Genres),

                    Synopsis = aDto.Synopsis,

                    Studios = string.Join(", ", aDto.Studios),

                    EpisodeDuration = aDto.EpisodeDuration,

                    Trailer = aDto.Trailer,
                };
                animes.Add(anime);
            }

            dbContext.Animes.AddRange(animes);
            dbContext.SaveChanges();
        }
    }
}
