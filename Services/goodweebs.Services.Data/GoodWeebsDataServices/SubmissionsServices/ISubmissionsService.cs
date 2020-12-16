namespace GoodWeebs.Services.Data.GoodWeebsDataServices.SubmissionsServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using global::GoodWeebs.Web.ViewModels.SubmissionInputModels;
    using global::GoodWeebs.Web.ViewModels.SubmissionModels;

    public interface ISubmissionsService
    {
        List<SubmissionInListViewModel> GetAll(int page, int itemsPerPage);

        AnimeSubmissionInputModel GetAnimeSubmission(int id);

        MangaSubmissionInputModel GetMangaSubmission(int id);

        ArticleSubmissionInputModel GetArticleSubmission(int id);

        int GetCount();

        Task ApproveAnimeSubmission(AnimeSubmissionInputModel input);

        Task ApproveMangaSubmission(MangaSubmissionInputModel input);

        Task ApproveArticleSubmission(ArticleSubmissionInputModel input);

        Task RemoveSubmission(int id, string type, string approvalStatus);

        Task UpdateUserSubmissionCount(string userId);
    }
}
