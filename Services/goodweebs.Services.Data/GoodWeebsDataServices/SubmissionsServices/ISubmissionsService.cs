namespace GoodWeebs.Services.Data.GoodWeebsDataServices.SubmissionsServices
{
    using global::GoodWeebs.Web.ViewModels.SubmissionInputModels;
    using global::GoodWeebs.Web.ViewModels.SubmissionModels;
    using Goodweebs.Web.ViewModels.SubmissionModels;
    using System.Collections.Generic;

    public interface ISubmissionsService
    {
        List<SubmissionInListViewModel> GetAll(int page, int itemsPerPage);

        AnimeSubmissionInputModel GetAnimeSubmission(int id);

        MangaSubmissionInputModel GetMangaSubmission(int id);

        ArticleSubmissionInputModel GetArticleSubmission(int id);
        int GetCount();
    }
}
