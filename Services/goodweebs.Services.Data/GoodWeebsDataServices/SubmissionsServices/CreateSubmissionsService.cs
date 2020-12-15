namespace GoodWeebs.Services.GoodWeebs.Services.SubmissionsServices
{
    using System.Linq;
    using System.Threading.Tasks;
    using global::GoodWeebs.Data.Common.Repositories;
    using global::GoodWeebs.Data.Models;
    using global::GoodWeebs.Web.ViewModels.SubmissionInputModels;
    using Goodweebs.Data.Models.Submissions;

    public class CreateSubmissionsService : ICreateSubmissionsService
    {
        private readonly IDeletableEntityRepository<AnimeSumbission> asubRepo;
        private readonly IDeletableEntityRepository<MangaSubmission> mSubRepo;
        private readonly IDeletableEntityRepository<ArticleSubmission> articleSubRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;

        public CreateSubmissionsService(
            IDeletableEntityRepository<AnimeSumbission> asubRepo,
            IDeletableEntityRepository<MangaSubmission> mSubRepo,
            IDeletableEntityRepository<ArticleSubmission> articleSubRepo,
            IDeletableEntityRepository<ApplicationUser> userRepo)
        {
            this.asubRepo = asubRepo;
            this.mSubRepo = mSubRepo;
            this.articleSubRepo = articleSubRepo;
            this.userRepo = userRepo;
        }

        public async Task SubmitAnimeWithUrlAsync(string url, string userId)
        {
            var user = this.userRepo.All().FirstOrDefault(x => x.Id == userId);
            var urlSubmission = new AnimeSumbission()
            {
                SubmitterId = userId,
                SubmissionUrl = url,
                SubmissionType = "Url",
                Submitter = user,
            };
            await this.asubRepo.AddAsync(urlSubmission);
        }

        public async Task SubmitAnimeFullAsync(AnimeSubmissionInputModel model, string userId, string submissionType)
        {
            var user = this.userRepo.All().FirstOrDefault(x => x.Id == userId);

            var animeSubmission = new AnimeSumbission()
            {
                SubmitterId = userId,
                Submitter = user,
                SubmissionType = submissionType,
                Title = model.Title,
                Genres = string.Join(", ", model.Genres),
                Picture = model.PictureUrl,
                Type = model.Type,
                Synopsis = model.Synopsis,
                Episodes = model.Episodes.ToString(),
                Status = string.Join(" ", model.Status),
                Aired = model.Aired,
                Trailer = model.Trailer,
                Synonyms = model.Synonyms,
                EpisodeDuration = model.Duration.ToString(),
                Rating = model.Rating[0],
                Studios = string.Join(", ", model.Studios),

            };
            await this.asubRepo.AddAsync(animeSubmission);
            await this.asubRepo.SaveChangesAsync();
        }

        public async Task SubmitArticleAsync(ArticleSubmissionInputModel model, string userId)
        {
            var user = this.userRepo.All().FirstOrDefault(x => x.Id == userId);
            var articleSub = new ArticleSubmission() { SubbmiterId = userId, Submitter = user, Title = model.Title, Content = model.Content };
            await this.articleSubRepo.AddAsync(articleSub);


        }

        public async Task SubmitMangaFullAsync(MangaSubmissionInputModel model, string userId, string submissionType)
        {
            var user = this.userRepo.All().FirstOrDefault(x => x.Id == userId);

            MangaSubmission mangaSubmission = new MangaSubmission()
                {
                    SubmitterId = userId,
                    Submitter = user,
                    SubmissionType = submissionType,
                    Title = model.Title,
                    Genres = string.Join(", ",model.Genres),
                    Picture = model.PictureUrl,
                    Type = model.Type,
                    Synopsis = model.Synopsis,
                    Status = model.Status,
                    Authors = model.Authors,
                    Volumes = model.Volumes.ToString(),
                    Chapters = model.Chapters,
                    Published = model.Published,

                };
            await this.mSubRepo.AddAsync(mangaSubmission);
        }

        public async Task SubmitMangaWithUrlAsync(string url, string userId)
        {
            var user = this.userRepo.All().FirstOrDefault(x => x.Id == userId);

            var urlSubmission = new MangaSubmission()
            {
                SubmitterId = userId,
                SubmissionUrl = url,
                SubmissionType = "Url",
                Submitter = user,
            };

            await this.mSubRepo.AddAsync(urlSubmission);
        }
    }
}
