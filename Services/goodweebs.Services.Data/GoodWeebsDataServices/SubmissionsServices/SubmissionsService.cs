namespace GoodWeebs.Services.Data.GoodWeebsDataServices.SubmissionsServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Entities;
    using global::GoodWeebs.Data.Common.Repositories;
    using global::GoodWeebs.Data.Models;
    using global::GoodWeebs.Data.Models.Submissions;
    using global::GoodWeebs.Web.ViewModels.SubmissionInputModels;
    using global::GoodWeebs.Web.ViewModels.SubmissionModels;
    using Microsoft.AspNetCore.Identity;

    public class SubmissionsService : ISubmissionsService
    {
        private readonly IDeletableEntityRepository<AnimeSubmission> animeSubRepo;
        private readonly IDeletableEntityRepository<MangaSubmission> mangaSubRepo;
        private readonly IDeletableEntityRepository<ArticleSubmission> articleSubRepo;
        private readonly IDeletableEntityRepository<Anime> animeRepo;
        private readonly IDeletableEntityRepository<Manga> mangaRepo;
        private readonly IDeletableEntityRepository<Article> articleRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;
        private readonly UserManager<ApplicationUser> userManager;

        public SubmissionsService(
            IDeletableEntityRepository<AnimeSubmission> animeSubRepo,
            IDeletableEntityRepository<MangaSubmission> mangaSubRepo,
            IDeletableEntityRepository<ArticleSubmission> articleSubRepo,
            IDeletableEntityRepository<Anime> animeRepo,
            IDeletableEntityRepository<Manga> mangaRepo,
            IDeletableEntityRepository<Article> articleRepo,
            IDeletableEntityRepository<ApplicationUser> userRepo,
            UserManager<ApplicationUser> userManager)
        {
            this.animeSubRepo = animeSubRepo;
            this.mangaSubRepo = mangaSubRepo;
            this.articleSubRepo = articleSubRepo;
            this.animeRepo = animeRepo;
            this.mangaRepo = mangaRepo;
            this.articleRepo = articleRepo;
            this.userRepo = userRepo;
            this.userManager = userManager;
        }

        public List<SubmissionInListViewModel> GetAll(int page, int itemsPerPage)
        {
            var submissions = new List<SubmissionInListViewModel>();
            var animeSubmissions = this.animeSubRepo.All().ToList();

            foreach (var sub in animeSubmissions)
            {
                submissions.Add(new SubmissionInListViewModel { Title = sub.Title, Id = sub.Id, SubmissionType = "Anime", CreatedOn = sub.CreatedOn });
            }

            var mangaSubmissions = this.mangaSubRepo.All().ToList();

            foreach (var sub in mangaSubmissions)
            {
                submissions.Add(new SubmissionInListViewModel { Title = sub.Title, Id = sub.Id, SubmissionType = "Manga", CreatedOn = sub.CreatedOn });
            }

            var articleSubmissions = new List<SubmissionInListViewModel>();
            this.articleSubRepo
                .All()
                .ToList()
                .ForEach(x => submissions
                .Add(new SubmissionInListViewModel { Title = x.Title, Id = x.Id, SubmissionType = "Article", CreatedOn = x.CreatedOn }));

            submissions = submissions.OrderBy(x => x.CreatedOn).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();

            return submissions;
        }

        public AnimeSubmissionInputModel GetAnimeSubmission(int id)
        {
            var animeSubmission = this.animeSubRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == id); // TODO Fix data types
            var result = new AnimeSubmissionInputModel
            {
                Title = animeSubmission.Title,
                Status = animeSubmission.Status,
                Studio = animeSubmission.Studios,
                Trailer = animeSubmission.Trailer,
                Synopsis = animeSubmission.Synopsis,
                Type = animeSubmission.Type,
                PictureUrl = animeSubmission.Picture,
                Aired = animeSubmission.Aired,
                Episodes = int.Parse(animeSubmission.Episodes),
                Duration = int.Parse(animeSubmission.EpisodeDuration),
                Rating = animeSubmission.Rating,
                Genres = animeSubmission.Genres.Split(", ").ToList(),
                SubmitterId = animeSubmission.SubmitterId,
            };
            return result;
        }

        public MangaSubmissionInputModel GetMangaSubmission(int id)
        {
            var mangaSubmission = this.mangaSubRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == id);
            var result = new MangaSubmissionInputModel
            {
                Title = mangaSubmission.Title,
                Status = mangaSubmission.Status,
                Authors = mangaSubmission.Authors,
                Synopsis = mangaSubmission.Synopsis,
                Type = mangaSubmission.Type,
                PictureUrl = mangaSubmission.Picture,
                Published = mangaSubmission.Published,
                Volumes = int.Parse(mangaSubmission.Volumes),
                Chapters = mangaSubmission.Chapters,
                Genres = mangaSubmission.Genres.Split(", ").ToList(),
            };
            return result;
        }

        public ArticleSubmissionInputModel GetArticleSubmission(int id)
        {
            var articleSubmission = this.articleSubRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == id);
            var result = new ArticleSubmissionInputModel
            {
                Title = articleSubmission.Title,
                Content = articleSubmission.Content,
            };
            return result;
        }

        public int GetCount() => this.animeSubRepo.AllAsNoTracking().Count() + this.mangaSubRepo.AllAsNoTracking().Count() + this.articleSubRepo.AllAsNoTracking().Count();

        public async Task ApproveAnimeSubmission(AnimeSubmissionInputModel input)
        {
            await this.animeRepo.AddAsync(new Anime
            {
                Title = input.Title,
                Status = input.Status,
                Studios = input.Studio,
                Synopsis = input.Synopsis,
                Aired = input.Aired,
                EpisodeDuration = input.Duration.ToString(),
                Episodes = input.Episodes.ToString(),
                Genres = string.Join(", ", input.Genres),
                Picture = input.PictureUrl,
                Rating = input.Rating,
                Trailer = input.Trailer,
                Type = input.Type,
            });
            await this.animeRepo.SaveChangesAsync();
        }

        public async Task ApproveMangaSubmission(MangaSubmissionInputModel input)
        {
            await this.mangaRepo.AddAsync(new Manga
            {
                Title = input.Title,
                Status = input.Status,
                Authors = string.Join(", ", input.Authors),
                Synopsis = input.Synopsis,
                Published = input.Published,
                Volumes = input.Volumes.ToString(),
                Chapters = input.Chapters,
                Genres = string.Join(", ", input.Genres),
                PictureUrl = input.PictureUrl,
                Type = input.Type,
            });
            await this.mangaRepo.SaveChangesAsync();
        }

        public async Task ApproveArticleSubmission(ArticleSubmissionInputModel input)
        {
            await this.articleRepo.AddAsync(new Article
            {
                Title = input.Title,
                Content = input.Content,

                // TODO AUTHOR = Submitter
            });
            await this.animeRepo.SaveChangesAsync();
        }

        public async Task RemoveSubmission(int id, string type, string approvalStatus)
        {
            if (type == "Anime")
            {
                var sub = this.animeSubRepo.All().Where(x => x.Id == id).FirstOrDefault();
                this.animeSubRepo.HardDelete(sub);
                await this.animeSubRepo.SaveChangesAsync();
            }
            else if (type == "Manga")
            {
                var sub = this.mangaSubRepo.All().Where(x => x.Id == id).FirstOrDefault();
                this.mangaSubRepo.HardDelete(sub);
                await this.mangaSubRepo.SaveChangesAsync();
            }
            else if (type == "Article")
            {
                var sub = this.articleSubRepo.All().Where(x => x.Id == id).FirstOrDefault();
                this.articleSubRepo.HardDelete(sub);
                await this.articleSubRepo.SaveChangesAsync();
            }
        }

    }
}
