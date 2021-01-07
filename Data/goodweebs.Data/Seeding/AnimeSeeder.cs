namespace GoodWeebs.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Azure.Storage.Blobs;
    using Entities;
    using GoodWeebs.Data.Models;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;

    public class AnimeSeeder : ISeeder
    {

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            if (dbContext.Animes.Any())
            {
                return;
            }
            var blob = serviceProvider.GetRequiredService<BlobServiceClient>();
            var container = blob.GetBlobContainerClient("goodweebs");
            var files = container.GetBlobClient("animes.json");
            string json = null;
            var stream = files.OpenRead();
            using (StreamReader r = new StreamReader(stream))
            {
                json = r.ReadToEnd();
                stream.Close();
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
            await dbContext.SaveChangesAsync();
        }
    }
}
