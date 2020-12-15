using Goodweebs.Data.Models.Submissions;
using GoodWeebs.Data.Common.Repositories;
using GoodWeebs.Data.Models;
using GoodWeebs.Web.ViewModels.SubmissionModels;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Goodweebs.Web.ViewModels.SubmissionModels;
using GoodWeebs.Web.ViewModels.SubmissionInputModels;

namespace GoodWeebs.Services.Data.GoodWeebsDataServices.SubmissionsServices
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly IDeletableEntityRepository<AnimeSumbission> animeSubRepo;
        private readonly IDeletableEntityRepository<MangaSubmission> mangaSubRepo;
        private readonly IDeletableEntityRepository<ArticleSubmission> articleSubRepo;

        public SubmissionsService(
            IDeletableEntityRepository<AnimeSumbission> animeSubRepo,
            IDeletableEntityRepository<MangaSubmission> mangaSubRepo,
            IDeletableEntityRepository<ArticleSubmission> articleSubRepo)
        {
            this.animeSubRepo = animeSubRepo;
            this.mangaSubRepo = mangaSubRepo;
            this.articleSubRepo = articleSubRepo;
        }

        public List<SubmissionInListViewModel> GetAll(int page, int itemsPerPage)
        {
            var submissions = new List<SubmissionInListViewModel>();
            var animeSubmissions = new List<SubmissionInListViewModel>();
            this.animeSubRepo.All()
                .ToList()
                .ForEach(x => submissions
                .Add(new SubmissionInListViewModel { Title = x.Title, Id = x.Id, SubmissionType = "Anime", CreatedOn = x.CreatedOn }));

            var mangaSubmissions = new List<SubmissionInListViewModel>();
            this.articleSubRepo.All()
                .ToList()
                .ForEach(x => submissions
                .Add(new SubmissionInListViewModel { Title = x.Title, Id = x.Id, SubmissionType = "Manga", CreatedOn = x.CreatedOn }));

            var articleSubmissions = new List<SubmissionInListViewModel>();
            this.mangaSubRepo
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
                Status = animeSubmission.Status.Split(", ").ToList(),
                Studios = animeSubmission.Studios.Split(", ").ToList(),
                Trailer = animeSubmission.Trailer,
                Synopsis = animeSubmission.Synopsis,
                Type = animeSubmission.Type,
                PictureUrl = animeSubmission.Picture,
                Aired = animeSubmission.Aired,
                Episodes = int.Parse(animeSubmission.Episodes),
                Duration = int.Parse(animeSubmission.EpisodeDuration),
                Rating = animeSubmission.Rating.Split(", ").ToList(),
                Genres = animeSubmission.Genres.Split(", ").ToList(),
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

    }
}
