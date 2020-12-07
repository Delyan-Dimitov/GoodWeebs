namespace GoodWeebs.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Entities;
    using GoodWeebs.Data;
    using GoodWeebs.Data.Models;
    using Newtonsoft.Json;

    public class MangaSeeder: ISeeder
    {

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Mangas.Any())
            {
                return;
            }

            string json = null;
            using (StreamReader r = new StreamReader(@"C:\Users\gunex\Desktop\GoodWeebs\Web\GoodWeebs.Web\wwwroot\mangas.json"))
            {
                json = r.ReadToEnd();
            }

            var mangaDTOs = JsonConvert.DeserializeObject<MangaDto[]>(json);
            List<Manga> mangas = new List<Manga>();
            foreach (MangaDto mDto in mangaDTOs)
            {
                var manga = new Manga()
                {
                    Title = mDto.Title,

                    Type = mDto.Type,

                    Volumes = mDto.Volumes,

                    Status = mDto.Status,

                    Published = mDto.Published,

                    PictureUrl = mDto.PictureUrl,

                    Genres = string.Join(", ", mDto.Genres),

                    Synopsis = mDto.Synopsis,

                    Authors = string.Join(", ", mDto.Authors),

                    Chapters = mDto.Chapters,

                };
                mangas.Add(manga);
            }

            dbContext.Mangas.AddRange(mangas);
            await dbContext.SaveChangesAsync();
        }
    }
}
