namespace goodweebs.Services.GoodWeebs.Services.SubmissionsServices
{
    using System.Linq;
    using System.Threading.Tasks;

    using GoodWeebs.Data.Common.Repositories;
    using GoodWeebs.Data.Models;
    using Goodweebs.Data.Models.Submissions;
    using goodweebs.Services.GoodWeebs.Services.SubmissionsServices;
    using GoodWeebs.Web.ViewModels.AnimeViewModels;
    using GoodWeebs.Web.ViewModels.SubmissionInputModels;

    public class SubmissionsService : ISubmissionsService
    {
        private readonly IDeletableEntityRepository<AnimeSumbission> asubRepo;
        private readonly IDeletableEntityRepository<MangaSubmission> mSubRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;

        public SubmissionsService(IDeletableEntityRepository<AnimeSumbission> asubRepo, IDeletableEntityRepository<MangaSubmission> mSubRepo, IDeletableEntityRepository<ApplicationUser> userRepo)
        {
            this.asubRepo = asubRepo;
            this.mSubRepo = mSubRepo;
            this.userRepo = userRepo;
        }

        public async Task SubmitAnimeAsync(AnimeSubmissionInputModel model, string userId, string submissionType)
        {
            var user = this.userRepo.All().FirstOrDefault(x => x.Id == userId);
            if (submissionType == "Url")
            {
                var urlSubmission = new AnimeSumbission()
                {
                    SubmitterId = userId,
                    SubmissionUrl = model.SubmissionUrl,
                    SubmissionType = submissionType,
                    Submitter = user,
                };

                await this.asubRepo.AddAsync(urlSubmission);
            }
            else
            {
                var animeSubmission = new AnimeSumbission()
                {
                    SubmitterId = userId,
                    Submitter = user,
                    SubmissionType = submissionType,
                    Title = model.Title,
                    Genres = model.Genres,
                    Picture = model.PictureUrl,
                    Type = model.Type,
                    Synopsis = model.Synopsis,
                    Episodes = model.Episodes,
                    Status = model.Status,
                    Aired = model.Aired,
                    Trailer = model.Trailer,
                    Synonyms = model.Synonyms,
                    EpisodeDuration = model.Duration,
                    Rating = model.Rating,
                    Studios = model.Studios,

                };
                await this.asubRepo.AddAsync(animeSubmission);
            }
        }

        public async Task SubmitArticleAsync(ArticleSubmissionInputModel model, string userId)
        {
            var user = this.userRepo.All().FirstOrDefault(x => x.Id == userId);
            var articleSub = new ArticleSubmission() { SubbmiterId = userId, Submitter = user, Title = model.Title, Content = model.Content };


        }

        public async Task SubmitMangaAsync(MangaSubmissionInputModel model, string userId, string submissionType)
        {
            var user = this.userRepo.All().FirstOrDefault(x => x.Id == userId);
            if (submissionType == "Url")
            {
                var urlSubmission = new MangaSubmission()
                {
                    SubmitterId = userId,
                    SubmissionUrl = model.SubmissionUrl,
                    SubmissionType = submissionType,
                    Submitter = user,
                };

                await this.mSubRepo.AddAsync(urlSubmission);
            }
            else
            {
                var mangaSubmission = new MangaSubmission()
                {
                    SubmitterId = userId,
                    Submitter = user,
                    SubmissionType = submissionType,
                    Title = model.Title,
                    Genres = model.Genres,
                    Picture = model.Picture,
                    Type = model.Type,
                    Synopsis = model.Synopsis,
                    Status = model.Status,
                    Rating = model.Rating,
                    Authors = model.Authors,
                    Volumes = model.Volumes,
                    Chapters = model.Chapters,
                    Published = model.Published,

                };
                await this.mSubRepo.AddAsync(mangaSubmission);
            }
        }
    }
}
