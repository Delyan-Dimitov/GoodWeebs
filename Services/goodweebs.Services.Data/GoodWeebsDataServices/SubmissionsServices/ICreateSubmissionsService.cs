using GoodWeebs.Web.ViewModels.SubmissionInputModels;
using System.Threading.Tasks;

namespace GoodWeebs.Services.GoodWeebs.Services.SubmissionsServices
{
    public interface ICreateSubmissionsService
    {
        Task SubmitAnimeFullAsync(AnimeSubmissionInputModel model, string userID, string submissionType);

        Task SubmitMangaFullAsync(MangaSubmissionInputModel model, string userID, string submissionType);

        Task SubmitArticleAsync(ArticleSubmissionInputModel model, string userID);

        Task SubmitAnimeWithUrlAsync(string url, string userId);

        Task SubmitMangaWithUrlAsync(string url, string userId);
    }
}
